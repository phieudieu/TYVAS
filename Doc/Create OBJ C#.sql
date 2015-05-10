DECLARE @script VARCHAR(MAX)
DECLARE @Region VARCHAR(MAX)

DECLARE contact_cursor CURSOR FOR
select column_name from information_schema.columns WHERE table_name = 'Attender';

OPEN contact_cursor;
-- Perform the first fetch.
FETCH NEXT FROM contact_cursor  into @script;

-- Check @@FETCH_STATUS to see if there are any more rows to fetch.
WHILE @@FETCH_STATUS = 0
BEGIN 
  print 'public Const F' + @script + '  = "' + @script + '";'
   FETCH NEXT FROM contact_cursor into @script;
END
 
CLOSE contact_cursor;
DEALLOCATE contact_cursor;
GO

---------------------------------------------------
DECLARE @script VARCHAR(MAX)
DECLARE @Region VARCHAR(MAX)
DECLARE @Index VARCHAR(MAX)
DECLARE contact_cursor CURSOR FOR
select 'private '  + 
CASE UPPER(convert(nvarchar,Data_Type))
	     WHEN UPPER('Float') THEN 'double'
		 WHEN UPPER('money') THEN 'Decimal'
         WHEN UPPER('int') THEN 'int'
         WHEN UPPER('datetime') THEN 'DateTime'
         WHEN UPPER('nvarchar') THEN 'string'
		 WHEN UPPER('varchar') THEN 'string'
		 WHEN UPPER('text') THEN 'string'
         WHEN UPPER('varbinary') THEN 'Byte()'
		 WHEN UPPER('Image') THEN 'Image'
		 WHEN UPPER('Decimal') THEN 'Decimal'
		  WHEN UPPER('tinyint') THEN 'int'
         ELSE 'Not for sale'
      END
	  + ' m_' +column_name +';'
 from information_schema.columns WHERE table_name = 'User';

SET @Index=0
OPEN contact_cursor;
-- Perform the first fetch.
FETCH NEXT FROM contact_cursor  into @script;

-- Check @@FETCH_STATUS to see if there are any more rows to fetch.
WHILE @@FETCH_STATUS = 0
BEGIN
 
  print @script
  SET @Index=@Index+1
   FETCH NEXT FROM contact_cursor into @script;
END

CLOSE contact_cursor;
DEALLOCATE contact_cursor;
GO
---------------------------------------------------------------

DECLARE @ColName VARCHAR(MAX)
DECLARE @colType VARCHAR(MAX)
DECLARE @Region VARCHAR(MAX)
DECLARE contact_cursor CURSOR FOR
select column_name,
CASE UPPER(convert(nvarchar,Data_Type))
	     WHEN UPPER('Float') THEN '0;'
		 WHEN UPPER('money') THEN '0;'
         WHEN UPPER('int') THEN '0;'
         WHEN UPPER('datetime') THEN 'DateTime.MinValue;'
         WHEN UPPER('nvarchar') THEN 'String.Empty;'
		 WHEN UPPER('varchar') THEN 'String.Empty;'
		 WHEN UPPER('text') THEN 'String.Empty;'
         WHEN UPPER('varbinary') THEN 'null;'
		 WHEN UPPER('Image') THEN 'null;'
		 WHEN UPPER('Decimal') THEN '0;'
		 WHEN UPPER('tinyint') THEN '0;'
         ELSE 'NTFAULT;'
      END
 from information_schema.columns WHERE table_name = 'User';
 SET @Region = (select 'public ' +'User()
{')
print @Region
OPEN contact_cursor;
-- Perform the first fetch.
FETCH NEXT FROM contact_cursor  into @colName,@colType;

-- Check @@FETCH_STATUS to see if there are any more rows to fetch.
WHILE @@FETCH_STATUS = 0
BEGIN
   print 'm_'   +@colName + ' = ' + @colType
    FETCH NEXT FROM contact_cursor into @colName,@colType;
END
SET @Region = (select '}')
print @Region

CLOSE contact_cursor;
DEALLOCATE contact_cursor;
GO
-------------------------------

DECLARE @col VARCHAR(MAX)
DECLARE @colType VARCHAR(MAX)
DECLARE @Region VARCHAR(MAX)
DECLARE @Index VARCHAR(MAX)
DECLARE contact_cursor CURSOR FOR
select column_name,
CASE UPPER(convert(nvarchar,Data_Type))
	     WHEN UPPER('Float') THEN 'double'
		 WHEN UPPER('money') THEN 'Decimal'
         WHEN UPPER('int') THEN 'int'
         WHEN UPPER('datetime') THEN 'DateTime'
         WHEN UPPER('nvarchar') THEN 'string'
		 WHEN UPPER('varchar') THEN 'string'
		 WHEN UPPER('text') THEN 'string'
         WHEN UPPER('varbinary') THEN 'Byte()'
		 WHEN UPPER('Image') THEN 'Image'
		 WHEN UPPER('Decimal') THEN 'Decimal'
		 WHEN UPPER('tinyint') THEN 'int'
         ELSE 'Not for sale'
      END
 from information_schema.columns WHERE table_name = 'User';
OPEN contact_cursor;
-- Perform the first fetch.
FETCH NEXT FROM contact_cursor  into @col,@colType;
-- Check @@FETCH_STATUS to see if there are any more rows to fetch.
WHILE @@FETCH_STATUS = 0
BEGIN
  print 'public ' +@colType +'  ' + @col 
  print '{
  get {'+	'return m_' + @col+ ';}'
  print '  set {' + 'm_' + @col + ' = value;}'

  print '}'
   FETCH NEXT FROM contact_cursor into  @col,@colType;
END

CLOSE contact_cursor;
DEALLOCATE contact_cursor;
GO