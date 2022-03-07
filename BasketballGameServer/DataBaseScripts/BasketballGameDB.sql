CREATE DATABASE "BasketballGameDB";
GO

USE "BasketballGameDB"
GO

CREATE TABLE "Player"(
    "id" INT IDENTITY(1,1) NOT NULL,
    "height" FLOAT NOT NULL,
    "userId" INT NOT NULL,
    "teamId" INT NULL
);
ALTER TABLE
    "Player" ADD CONSTRAINT "player_id_primary" PRIMARY KEY("id");
CREATE TABLE "Team"(
    "id" INT IDENTITY(1,1) NOT NULL,
    "coachId" INT NOT NULL,
    "name" NVARCHAR(255) NOT NULL,
    "image" NVARCHAR(255) NULL
);
ALTER TABLE
    "Team" ADD CONSTRAINT "team_id_primary" PRIMARY KEY("id");
CREATE TABLE "Game"(
    "id" INT IDENTITY(1,1) NOT NULL,
    "homeTeamId" INT NOT NULL,
    "awayTeamId" INT NOT NULL,
    "gameStatusId" INT NOT NULL,
    "scoreAwayTeam" INT NOT NULL,
    "scoreHomeTeam" INT NOT NULL
);
ALTER TABLE
    "Game" ADD CONSTRAINT "game_id_primary" PRIMARY KEY("id");
CREATE TABLE "GameStats"(
    "id" INT IDENTITY(1,1) NOT NULL,
    "gameId" INT NOT NULL,
    "playerShots" INT NOT NULL,
    "playerId" INT NOT NULL
);
ALTER TABLE
    "GameStats" ADD CONSTRAINT "gamestats_id_primary" PRIMARY KEY("id");
CREATE TABLE "RequestGame"(
    "id" INT IDENTITY(1,1) NOT NULL,
    "requestStatusId" INT NOT NULL,
    "coachId" INT NOT NULL,
    "gameId" INT NOT NULL,
    "date" DATETIME NOT NULL,
    "time" TIME NOT NULL,
    "position" NVARCHAR(255) NOT NULL
);
ALTER TABLE
    "RequestGame" ADD CONSTRAINT "requestgame_id_primary" PRIMARY KEY("id");
CREATE TABLE "Coach"(
    "id" INT IDENTITY(1,1) NOT NULL,
    "userId" INT NOT NULL,
    "teamId" INT NULL
);
ALTER TABLE
    "Coach" ADD CONSTRAINT "coach_id_primary" PRIMARY KEY("id");
CREATE TABLE "RequestGameStatus"(
    "id" INT NOT NULL,
    "name" NVARCHAR(255) NOT NULL
);
ALTER TABLE
    "RequestGameStatus" ADD CONSTRAINT "requestgamestatus_id_primary" PRIMARY KEY("id");
CREATE TABLE "GameStatus"(
    "id" INT IDENTITY(1,1) NOT NULL,
    "name" NVARCHAR(255) NOT NULL
);
ALTER TABLE
    "GameStatus" ADD CONSTRAINT "gamestatus_id_primary" PRIMARY KEY("id");
CREATE TABLE "RequestToJoinTeam"(
    "id" INT IDENTITY(1,1) NOT NULL,
    "playerId" INT NOT NULL,
    "teamId" INT NOT NULL,
    "requestToJoinTeamStatusId" INT NOT NULL
);
ALTER TABLE
    "RequestToJoinTeam" ADD CONSTRAINT "requesttojointeam_id_primary" PRIMARY KEY("id");
CREATE TABLE "User"(
    "id" INT IDENTITY(1,1) NOT NULL,
    "email" NVARCHAR(255) NOT NULL,
    "pass" NVARCHAR(255) NOT NULL,
    "birthDate" DATETIME NOT NULL,
    "image" NVARCHAR(255) NULL,
    "gender" NVARCHAR(255) NOT NULL,
    "name" NVARCHAR(255) NOT NULL
);
ALTER TABLE
    "User" ADD CONSTRAINT "user_id_primary" PRIMARY KEY("id");
CREATE UNIQUE INDEX "user_email_unique" ON
    "User"("email");
CREATE TABLE "RequestToJoinTeamStatus"(
    "id" INT IDENTITY(1,1) NOT NULL,
    "name" NVARCHAR(255) NOT NULL
);
ALTER TABLE
    "RequestToJoinTeamStatus" ADD CONSTRAINT "requesttojointeamstatus_id_primary" PRIMARY KEY("id");
ALTER TABLE
    "RequestToJoinTeam" ADD CONSTRAINT "requesttojointeam_playerid_foreign" FOREIGN KEY("playerId") REFERENCES "Player"("id");
ALTER TABLE
    "GameStats" ADD CONSTRAINT "gamestats_playerid_foreign" FOREIGN KEY("playerId") REFERENCES "Player"("id");
ALTER TABLE
    "RequestToJoinTeam" ADD CONSTRAINT "requesttojointeam_teamid_foreign" FOREIGN KEY("teamId") REFERENCES "Team"("id");
ALTER TABLE
    "Game" ADD CONSTRAINT "game_awayteamid_foreign" FOREIGN KEY("awayTeamId") REFERENCES "Team"("id");
ALTER TABLE
    "Game" ADD CONSTRAINT "game_hometeamid_foreign" FOREIGN KEY("homeTeamId") REFERENCES "Team"("id");
ALTER TABLE
    "Coach" ADD CONSTRAINT "coach_teamid_foreign" FOREIGN KEY("teamId") REFERENCES "Team"("id");
ALTER TABLE
    "Player" ADD CONSTRAINT "player_teamid_foreign" FOREIGN KEY("teamId") REFERENCES "Team"("id");
ALTER TABLE
    "RequestGame" ADD CONSTRAINT "requestgame_gameid_foreign" FOREIGN KEY("gameId") REFERENCES "Game"("id");
ALTER TABLE
    "GameStats" ADD CONSTRAINT "gamestats_gameid_foreign" FOREIGN KEY("gameId") REFERENCES "Game"("id");
ALTER TABLE
    "RequestGame" ADD CONSTRAINT "requestgame_coachid_foreign" FOREIGN KEY("coachId") REFERENCES "Coach"("id");
ALTER TABLE
    "Team" ADD CONSTRAINT "team_coachid_foreign" FOREIGN KEY("coachId") REFERENCES "Coach"("id");
ALTER TABLE
    "Coach" ADD CONSTRAINT "coach_userid_foreign" FOREIGN KEY("userId") REFERENCES "User"("id");
ALTER TABLE
    "RequestGame" ADD CONSTRAINT "requestgame_requeststatusid_foreign" FOREIGN KEY("requestStatusId") REFERENCES "RequestGameStatus"("id");
ALTER TABLE
    "Game" ADD CONSTRAINT "game_gamestatusid_foreign" FOREIGN KEY("gameStatusId") REFERENCES "GameStatus"("id");
ALTER TABLE
    "Player" ADD CONSTRAINT "player_userid_foreign" FOREIGN KEY("userId") REFERENCES "User"("id");
ALTER TABLE
    "RequestToJoinTeam" ADD CONSTRAINT "requesttojointeam_requesttojointeamstatusid_foreign" FOREIGN KEY("requestToJoinTeamStatusId") REFERENCES "RequestToJoinTeamStatus"("id");