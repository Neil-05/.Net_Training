using System;
using System.Collections.Generic;
using System.Linq;

#region Core Contracts

public interface IFinancialInstrument
{
    string Symbol { get; }
    decimal CurrentPrice { get; }
    InstrumentType Type { get; }
}

public enum InstrumentType
{
    Stock,
    Bond,
    Option,
    Future
}

public enum Trend
{
    Upward,
    Downward,
    Sideways
}

#endregion

#region Portfolio

public class Portfolio<T> where T : IFinancialInstrument
{
    private Dictionary<T, int> _holdings = new();

    public IReadOnlyDictionary<T, int> Holdings => _holdings;

    // BUY
    public void Buy(T instrument, int quantity, decimal price)
    {
        if (instrument == null)
            throw new ArgumentNullException(nameof(instrument));

        if (quantity <= 0 || price <= 0)
            throw new ArgumentException("Quantity and price must be greater than zero.");

        if (_holdings.ContainsKey(instrument))
            _holdings[instrument] += quantity;
        else
            _holdings[instrument] = quantity;
    }

    // SELL
    public decimal? Sell(T instrument, int quantity, decimal currentPrice)
    {
        if (instrument == null)
            throw new ArgumentNullException(nameof(instrument));

        if (!_holdings.ContainsKey(instrument))
            return null;

        if (quantity <= 0 || _holdings[instrument] < quantity)
            return null;

        _holdings[instrument] -= quantity;

        if (_holdings[instrument] == 0)
            _holdings.Remove(instrument);

        return quantity * currentPrice;
    }

    // TOTAL VALUE
    public decimal CalculateTotalValue()
    {
        return _holdings.Sum(h => h.Key.CurrentPrice * h.Value);
    }

    // TOP PERFORMER
    public (T instrument, decimal returnPercentage)? GetTopPerformer(
        Dictionary<T, decimal> purchasePrices)
    {
        if (!_holdings.Any())
            return null;

        var best = _holdings
            .Where(h => purchasePrices.ContainsKey(h.Key))
            .Select(h =>
            {
                decimal purchasePrice = purchasePrices[h.Key];
                decimal currentPrice = h.Key.CurrentPrice;

                decimal returnPct =
                    ((currentPrice - purchasePrice) / purchasePrice) * 100;

                return (instrument: h.Key, returnPercentage: returnPct);
            })
            .OrderByDescending(x => x.returnPercentage)
            .FirstOrDefault();

        return best;
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

    public override string ToString() => $"Stock: {Symbol}";
}

public class Bond : IFinancialInstrument
{
    public string Symbol { get; set; }
    public decimal CurrentPrice { get; set; }
    public InstrumentType Type => InstrumentType.Bond;

    public DateTime MaturityDate { get; set; }
    public decimal CouponRate { get; set; }

    public override string ToString() => $"Bond: {Symbol}";
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

            if (sellCondition(instrument))
                portfolio.Sell(instrument, 5, instrument.CurrentPrice);
        }
    }

    public Dictionary<string, decimal> CalculateRiskMetrics(
        IEnumerable<T> instruments)
    {
        var prices = instruments.Select(i => i.CurrentPrice).ToList();

        if (prices.Count < 2)
            return new Dictionary<string, decimal>();

        decimal average = prices.Average();
        decimal variance = prices.Sum(p => (p - average) * (p - average)) / prices.Count;
        decimal volatility = (decimal)Math.Sqrt((double)variance);

        decimal sharpeRatio = volatility == 0 ? 0 : average / volatility;

        return new Dictionary<string, decimal>
        {
            { "Volatility", volatility },
            { "Beta (Mock)", 1.0m },
            { "Sharpe Ratio", sharpeRatio }
        };
    }
}

#endregion

#region Price History

public class PriceHistory<T> where T : IFinancialInstrument
{
    private Dictionary<T, List<(DateTime, decimal)>> _history = new();

    public void AddPrice(T instrument, DateTime timestamp, decimal price)
    {
        if (!_history.ContainsKey(instrument))
            _history[instrument] = new List<(DateTime, decimal)>();

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
            .ToList();

        if (prices.Count < 2)
            return Trend.Sideways;

        if (prices.First() > prices.Last())
            return Trend.Upward;

        if (prices.First() < prices.Last())
            return Trend.Downward;

        return Trend.Sideways;
    }
}

#endregion

#region Test Simulation

public class Program
{
    public static void Main()
    {
        var apple = new Stock
        {
            Symbol = "AAPL",
            CompanyName = "Apple Inc",
            CurrentPrice = 180m,
            DividendYield = 0.01m
        };

        var tesla = new Stock
        {
            Symbol = "TSLA",
            CompanyName = "Tesla",
            CurrentPrice = 250m,
            DividendYield = 0m
        };

        var bond = new Bond
        {
            Symbol = "US10Y",
            CurrentPrice = 100m,
            CouponRate = 0.03m,
            MaturityDate = DateTime.Now.AddYears(10)
        };

        var portfolio = new Portfolio<IFinancialInstrument>();

        // BUY
        portfolio.Buy(apple, 20, apple.CurrentPrice);
        portfolio.Buy(tesla, 10, tesla.CurrentPrice);
        portfolio.Buy(bond, 50, bond.CurrentPrice);

        Console.WriteLine("Initial Portfolio Value: " + portfolio.CalculateTotalValue());

        // STRATEGY
        var strategy = new TradingStrategy<IFinancialInstrument>();

        strategy.Execute(
            portfolio,
            new List<IFinancialInstrument> { apple, tesla, bond },
            i => i.CurrentPrice < 200,
            i => i.CurrentPrice > 240
        );

        Console.WriteLine("After Strategy Value: " + portfolio.CalculateTotalValue());

        // PRICE HISTORY
        var history = new PriceHistory<IFinancialInstrument>();

        history.AddPrice(apple, DateTime.Now.AddDays(-3), 160);
        history.AddPrice(apple, DateTime.Now.AddDays(-2), 170);
        history.AddPrice(apple, DateTime.Now.AddDays(-1), 180);

        Console.WriteLine("Apple MA(3): " + history.GetMovingAverage(apple, 3));
        Console.WriteLine("Apple Trend: " + history.DetectTrend(apple, 3));

        // RISK METRICS
        var metrics = strategy.CalculateRiskMetrics(new List<IFinancialInstrument> { apple, tesla, bond });

        Console.WriteLine("\nRisk Metrics:");
        foreach (var metric in metrics)
            Console.WriteLine($"{metric.Key}: {metric.Value}");

        // PERFORMANCE COMPARISON
        var purchasePrices = new Dictionary<IFinancialInstrument, decimal>
        {
            { apple, 150m },
            { tesla, 200m },
            { bond, 100m }
        };

        var top = portfolio.GetTopPerformer(purchasePrices);

        if (top.HasValue)
            Console.WriteLine($"\nTop Performer: {top.Value.instrument.Symbol} ({top.Value.returnPercentage:F2}%)");
    }
}

#endregion
