IF NOT EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[vwTicket]'))
EXEC dbo.sp_executesql @statement = N'CREATE VIEW [dbo].[vwTicket]
	AS SELECT 
	t.*
	, p.Description AS ProductDescription
	, s.DisplayName AS Severity
	FROM Ticket t 
	INNER JOIN Product p ON t.ProductId = p.ProductId
	INNER JOIN Severity s ON s.SeverityId = t.SeverityId' 
