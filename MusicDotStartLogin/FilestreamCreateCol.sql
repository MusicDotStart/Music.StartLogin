--Create a ROWGUID column
USE MusicDotStart
ALTER Table audio
Add columname uniqueidentifier not null ROWGUIDCOL unique default newid()
GO
--b) Turn on FILESTREAM
USE MusicDotStart
ALTER Table audio
SET (filestream_on=FILESTREAMGroupName)
GO
--c) Add FILESTREAM column to the table
USE MusicDotStart
ALTER Table audio
Add data2 varbinary(max) FILESTREAM null
GO
--d) Move data into the new column
UPDATE audio
SET data2=data
GO
--e) Drop the old column
ALTER Table audio
DROP column data
GO
--f) Rename the new FILESTREAM column to the old column name
Use MusicDotStart
EXEC sp_rename MusicDotStart.data2’, ‘data’, ‘COLUMN’
GO
