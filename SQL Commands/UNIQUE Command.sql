CREATE UNIQUE NONCLUSTERED INDEX UQ_User_bookId ON
[User](bookId) WHERE bookId IS NOT NULL