using System;
using System.Collections.Generic;
using System.Linq;

#region Interfaces & Enums

public interface IFinancialInstrument
{
    string Symbol { get; }
    decimal CurrentPrice { get; }
    InstrumentType Type { get; }
}

public enum InstrumentType { Stock, Bond, Option, Future }
public enum Trend { Upward, Downward, Sideways }

#endregion

#region Portfolio

public class Portfolio<T> where T : IFinancialInstrument
{
    private readonly Dictionary<T, int> _holdings = new();

    public IReadOnlyDictionary<T, int> Holdings => _holdings;

    public void Buy(T instrument, int quantity, decimal price)
    {
        if (instrument == null)
            throw new ArgumentNullException(nameof(instrument));

        if (quantity <= 0)
            throw new ArgumentException("Quantity must be > 0");

        if (price <= 0)
            throw new ArgumentException("Price must be > 0");

        if (_holdings.ContainsKey(instrument))
            _holdings[instrument] += quantity;
        else
            _holdings[instrument] = quantity;

        Console.WriteLine($"Bought {quantity} of {instrument.Symbol} at {price}");
    }

    public decimal? Sell(T instrument, int quantity, decimal currentPrice)
    {
        if (!_holdings.ContainsKey(instrument))
            return null;

        if (quantity <= 0 || quantity > _holdings[instrument])
            return null;

        _holdings[instrument] -= quantity;

        if (_holdings[instrument] == 0)
            _holdings.Remove(instrument);

        decimal proceeds = quantity * currentPrice;
        Console.WriteLine($"Sold {quantity} of {instrument.Symbol} at {currentPrice}");

        return proceeds;
    }

    public decimal CalculateTotalValue()
    {
        return _holdings.Sum(h => h.Key.CurrentPrice * h.Value);
    }

    public (T instrument, decimal returnPercentage)? GetTopPerformer(
        Dictionary<T, decimal> purchasePrices)
    {
        if (!_holdings.Any())
            return null;

        var performances = _holdings
            .Where(h => purchasePrices.ContainsKey(h.Key))
            .Select(h =>
            {
                decimal buyPrice = purchasePrices[h.Key];
                decimal current = h.Key.CurrentPrice;
                decimal returnPct = ((current - buyPrice) / buyPrice) * 100;
                return (instrument: h.Key, returnPct);
            });

        if (!performances.Any())
            return null;

        return performances.OrderByDescending(p => p.returnPct).First();
    }
}

#endregion

#region Instruments

public class Stock : IFinancialInstrument
{
    public string Symbol { get; set; }
    public decimal CurrentPrice { get; set; }
    public InstrumentType Type => InstrumentType.Stock;
    public string CompanyName { get; set; }
    public decimal DividendYield { get; set; }
}

public class Bond : IFinancialInstrument
{
    public string Symbol { get; set; }
    public decimal CurrentPrice { get; set; }
    public InstrumentType Type => InstrumentType.Bond;
    public DateTime MaturityDate { get; set; }
    public decimal CouponRate { get; set; }
}

#endregion

#region Trading Strategy

public class TradingStrategy<T> where T : IFinancialInstrument
{
    public void Execute(
        Portfolio<T> portfolio,
        IEnumerable<T> marketData,
        Func<T, bool> buyCondition,
        Func<T, bool> sellCondition)
    {
        foreach (var instrument in marketData)
        {
            if (buyCondition(instrument))
                portfolio.Buy(instrument, 10, instrument.CurrentPrice);

            if (sellCondition(instrument) &&
                portfolio.Holdings.ContainsKey(instrument))
                portfolio.Sell(instrument, 5, instrument.CurrentPrice);
        }
    }

    public Dictionary<string, decimal> CalculateRiskMetrics(IEnumerable<T> instruments)
    {
        var prices = instruments.Select(i => i.CurrentPrice).ToList();

        if (!prices.Any())
            return new Dictionary<string, decimal>();

        decimal avg = prices.Average();
        decimal variance = prices.Average(p => (p - avg) * (p - avg));
        decimal volatility = (decimal)Math.Sqrt((double)variance);

        decimal beta = 1.0m;   // Simplified placeholder
        decimal sharpe = volatility == 0 ? 0 : avg / volatility;

        return new Dictionary<string, decimal>
        {
            { "Volatility", volatility },
            { "Beta", beta },
            { "SharpeRatio", sharpe }
        };
    }
}

#endregion

#region Price History

public class PriceHistory<T> where T : IFinancialInstrument
{
    private readonly Dictionary<T, List<(DateTime, decimal)>> _history = new();

    public void AddPrice(T instrument, DateTime timestamp, decimal price)
    {
        if (!_history.ContainsKey(instrument))
            _history[instrument] = new();

        _history[instrument].Add((timestamp, price));
    }

    public decimal? GetMovingAverage(T instrument, int days)
    {
        if (!_history.ContainsKey(instrument))
            return null;

        var prices = _history[instrument]
            .OrderByDescending(p => p.Item1)
            .Take(days)
            .Select(p => p.Item2)
            .ToList();

        if (!prices.Any())
            return null;

        return prices.Average();
    }

    public Trend DetectTrend(T instrument, int period)
    {
        if (!_history.ContainsKey(instrument))
            return Trend.Sideways;

        var prices = _history[instrument]
            .OrderByDescending(p => p.Item1)
            .Take(period)
            .Select(p => p.Item2)
            .Reverse()
            .ToList();

        if (prices.Count < 2)
            return Trend.Sideways;

        if (prices.Last() > prices.First())
            return Trend.Upward;

        if (prices.Last() < prices.First())
            return Trend.Downward;

        return Trend.Sideways;
    }
}

#endregion

#region Simulation

public class Program
{
    public static void Main()
    {
        var stock1 = new Stock { Symbol = "AAPL", CurrentPrice = 180, CompanyName = "Apple" };
        var stock2 = new Stock { Symbol = "MSFT", CurrentPrice = 350, CompanyName = "Microsoft" };
        var bond1 = new Bond { Symbol = "US10Y", CurrentPrice = 1000, MaturityDate = DateTime.Now.AddYears(10) };

        var portfolio = new Portfolio<IFinancialInstrument>();

        portfolio.Buy(stock1, 10, 170);
        portfolio.Buy(stock2, 5, 300);
        portfolio.Buy(bond1, 2, 950);

        Console.WriteLine($"\nTotal Portfolio Value: {portfolio.CalculateTotalValue()}");

        var purchasePrices = new Dictionary<IFinancialInstrument, decimal>
        {
            { stock1, 170 },
            { stock2, 300 },
            { bond1, 950 }
        };

        var top = portfolio.GetTopPerformer(purchasePrices);
        if (top != null)
            Console.WriteLine($"Top Performer: {top.Value.instrument.Symbol} ({top.Value.returnPercentage:F2}%)");

        var strategy = new TradingStrategy<IFinancialInstrument>();

        strategy.Execute(
            portfolio,
            new List<IFinancialInstrument> { stock1, stock2, bond1 },
            buyCondition: i => i.Type == InstrumentType.Stock && i.CurrentPrice < 200,
            sellCondition: i => i.Type == InstrumentType.Stock && i.CurrentPrice > 300
        );

        var risk = strategy.CalculateRiskMetrics(new List<IFinancialInstrument> { stock1, stock2, bond1 });

        Console.WriteLine("\nRisk Metrics:");
        foreach (var metric in risk)
            Console.WriteLine($"{metric.Key}: {metric.Value:F2}");

        var history = new PriceHistory<IFinancialInstrument>();

        history.AddPrice(stock1, DateTime.Today.AddDays(-3), 160);
        history.AddPrice(stock1, DateTime.Today.AddDays(-2), 170);
        history.AddPrice(stock1, DateTime.Today.AddDays(-1), 180);

        Console.WriteLine($"\nAAPL Moving Avg (3 days): {history.GetMovingAverage(stock1, 3)}");
        Console.WriteLine($"AAPL Trend: {history.DetectTrend(stock1, 3)}");
    }
}

#endregion
