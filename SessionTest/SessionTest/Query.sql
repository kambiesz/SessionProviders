-- Kwerenda z podusmowaniem

SELECT AVG(Time) as Ticks,Type
FROM [dbo].[SessionDatas]
GROUP BY Type
ORDER BY Ticks;