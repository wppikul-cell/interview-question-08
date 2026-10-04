CREATE TABLE Questions
(
    Id INT IDENTITY(1,1) PRIMARY KEY,
    QuestionText NVARCHAR(500) NOT NULL
);

CREATE TABLE QuestionChoices
(
    Id INT IDENTITY(1,1) PRIMARY KEY,
    QuestionId INT NOT NULL,
    ChoiceText NVARCHAR(200) NOT NULL,
    IsCorrect BIT NOT NULL DEFAULT 0,

    CONSTRAINT FK_QuestionChoices_Questions
        FOREIGN KEY (QuestionId)
        REFERENCES Questions(Id)
        ON DELETE CASCADE
);