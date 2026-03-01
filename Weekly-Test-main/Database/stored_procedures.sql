USE FlightDB;
GO

-- 1. Get List of Distinct Sources
CREATE PROCEDURE sp_GetSources
AS
BEGIN
    SELECT DISTINCT Source FROM Flights ORDER BY Source;
END;
GO

-- 2. Get List of Distinct Destinations
CREATE PROCEDURE sp_GetDestinations
AS
BEGIN
    SELECT DISTINCT Destination FROM Flights ORDER BY Destination;
END;
GO

-- 3. Search Flights Only
CREATE PROCEDURE sp_SearchFlights
    @Source NVARCHAR(100),
    @Destination NVARCHAR(100),
    @Persons INT
AS
BEGIN
    SELECT 
        FlightId, 
        FlightName, 
        FlightType, 
        Source, 
        Destination, 
        (PricePerSeat * @Persons) AS TotalCost
    FROM Flights
    WHERE Source = @Source AND Destination = @Destination;
END;
GO

-- 4. Search Flights with Hotels
CREATE PROCEDURE sp_SearchFlightsWithHotels
    @Source NVARCHAR(100),
    @Destination NVARCHAR(100),
    @Persons INT
AS
BEGIN
    SELECT 
        F.FlightId, 
        F.FlightName, 
        F.Source, 
        F.Destination, 
        H.HotelName, 
        ((F.PricePerSeat * @Persons) + H.PricePerDay) AS TotalCost
    FROM Flights F
    INNER JOIN Hotels H ON F.Destination = H.Location
    WHERE F.Source = @Source AND F.Destination = @Destination;
END;
GO
