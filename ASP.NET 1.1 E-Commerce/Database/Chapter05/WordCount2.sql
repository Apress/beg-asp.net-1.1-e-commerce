/* You may need to use your user name instead of dbo, 
   in which case you'll also need to update the SearchCatalog stored procedure */

CREATE FUNCTION dbo.WordCount
(@Word VARCHAR(20), 
@Phrase VARCHAR(1000))
RETURNS SMALLINT
AS
BEGIN

/* If @Word or @Phrase is NULL the function returns 0 */
IF @Word IS NULL OR @Phrase IS NULL RETURN 0

/* Calculate and store the SOUNDEX value of the word */
DECLARE @SoundexWord CHAR(4)
SELECT @SoundexWord = SOUNDEX(@Word)

/* Eliminate bogus characters from phrase */
SELECT @Phrase = REPLACE(@Phrase, ',', ' ')
SELECT @Phrase = REPLACE(@Phrase, '.', ' ')
SELECT @Phrase = REPLACE(@Phrase, '!', ' ')
SELECT @Phrase = REPLACE(@Phrase, '?', ' ')
SELECT @Phrase = REPLACE(@Phrase, ';', ' ')
SELECT @Phrase = REPLACE(@Phrase, '-', ' ')

/* Necessary because LEN doesn't calculate trailing spaces */
SELECT @Phrase = RTRIM(@Phrase)

/* Check every word in the phrase */
DECLARE @NextSpacePos SMALLINT
DECLARE @ExtractedWord VARCHAR(20)
DECLARE @Matches SMALLINT

SELECT @Matches = 0

WHILE LEN(@Phrase)>0
  BEGIN
     SELECT @NextSpacePos = CHARINDEX(' ', @Phrase)
     IF @NextSpacePos = 0 
       BEGIN
         SELECT @ExtractedWord = @Phrase
         SELECT @Phrase=''
       END
     ELSE
       BEGIN
         SELECT @ExtractedWord = LEFT(@Phrase, @NextSpacePos-1)
         SELECT @Phrase = RIGHT(@Phrase, LEN(@Phrase)-@NextSpacePos)
       END

     IF @SoundexWord = SOUNDEX(@ExtractedWord)
       SELECT @Matches = @Matches + 1
  END

/* Return the number of occurences of @Word in @Phrase */
RETURN @Matches
END
