CREATE TABLE "Player"(
    "id" INT IDENTITY(1,1) NOT NULL,
    "height" FLOAT NOT NULL,
    "name" NVARCHAR(255) NOT NULL,
    "userId" INT NOT NULL
);
ALTER TABLE
    "Player" ADD CONSTRAINT "player_id_primary" PRIMARY KEY("id");
CREATE TABLE "Team"(
    "id" INT IDENTITY(1,1) NOT NULL,
    "coachId" INT NOT NULL,
    "leagueId" INT NOT NULL,
    "name" NVARCHAR(255) NOT NULL,
    "image" NVARCHAR(255) NULL
);
ALTER TABLE
    "Team" ADD CONSTRAINT "team_id_primary" PRIMARY KEY("id");
CREATE TABLE "PlayerOnTeamForSeason"(
    "id" INT IDENTITY(1,1) NOT NULL,
    "playerId" INT NOT NULL,
    "teamId" INT NOT NULL,
    "seasonId" INT NOT NULL,
    "positionId" INT NOT NULL
);
ALTER TABLE
    "PlayerOnTeamForSeason" ADD CONSTRAINT "playeronteamforseason_id_primary" PRIMARY KEY("id");
CREATE TABLE "Position"(
    "id" INT IDENTITY(1,1) NOT NULL,
    "name" NVARCHAR(255) NOT NULL
);
ALTER TABLE
    "Position" ADD CONSTRAINT "position_id_primary" PRIMARY KEY("id");
CREATE TABLE "Season"(
    "id" INT IDENTITY(1,1) NOT NULL,
    "name" NVARCHAR(255) NOT NULL
);
ALTER TABLE
    "Season" ADD CONSTRAINT "season_id_primary" PRIMARY KEY("id");
CREATE TABLE "Game"(
    "id" INT IDENTITY(1,1) NOT NULL,
    "seasonId" INT NOT NULL,
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
    "plsyerShots" INT NOT NULL,
    "playerId" INT NOT NULL
);
ALTER TABLE
    "GameStats" ADD CONSTRAINT "gamestats_id_primary" PRIMARY KEY("id");
CREATE TABLE "RequestGame"(
    "id" INT IDENTITY(1,1) NOT NULL,
    "requestStatusId" INT NOT NULL,
    "coachId" INT NOT NULL,
    "gameId" INT NOT NULL
);
ALTER TABLE
    "RequestGame" ADD CONSTRAINT "requestgame_id_primary" PRIMARY KEY("id");
CREATE TABLE "Coach"(
    "id" INT IDENTITY(1,1) NOT NULL,
    "name" NVARCHAR(255) NOT NULL,
    "userId" INT NOT NULL
);
ALTER TABLE
    "Coach" ADD CONSTRAINT "coach_id_primary" PRIMARY KEY("id");
CREATE TABLE "RequestStatus"(
    "id" INT IDENTITY(1,1) NOT NULL,
    "name" NVARCHAR(255) NOT NULL
);
ALTER TABLE
    "RequestStatus" ADD CONSTRAINT "requeststatus_id_primary" PRIMARY KEY("id");
CREATE TABLE "League"(
    "id" INT IDENTITY(1,1) NOT NULL,
    "name" NVARCHAR(255) NOT NULL
);
ALTER TABLE
    "League" ADD CONSTRAINT "league_id_primary" PRIMARY KEY("id");
CREATE TABLE "GameStatus"(
    "id" INT IDENTITY(1,1) NOT NULL,
    "name" NVARCHAR(255) NOT NULL
);
ALTER TABLE
    "GameStatus" ADD CONSTRAINT "gamestatus_id_primary" PRIMARY KEY("id");
CREATE TABLE "RequestToJoinTeam"(
    "id" INT NOT NULL,
    "playerId" INT IDENTITY(1,1) NOT NULL,
    "teamId" INT NOT NULL
);
ALTER TABLE
    "RequestToJoinTeam" ADD CONSTRAINT "requesttojointeam_id_primary" PRIMARY KEY("id");
CREATE TABLE "User"(
    "id" INT IDENTITY(1,1) NOT NULL,
    "email" NVARCHAR(255) NOT NULL,
    "pass" NVARCHAR(255) NOT NULL,
    "birthDate" DATE NOT NULL,
    "image" NVARCHAR(255) NOT NULL,
    "gender" BIT NOT NULL,
    "city" NVARCHAR(255) NOT NULL
);
ALTER TABLE
    "User" ADD CONSTRAINT "user_id_primary" PRIMARY KEY("id");
CREATE UNIQUE INDEX "user_email_unique" ON
    "User"("email");
CREATE UNIQUE INDEX "user_pass_unique" ON
    "User"("pass");
ALTER TABLE
    "RequestToJoinTeam" ADD CONSTRAINT "requesttojointeam_playerid_foreign" FOREIGN KEY("playerId") REFERENCES "Player"("id");
ALTER TABLE
    "PlayerOnTeamForSeason" ADD CONSTRAINT "playeronteamforseason_playerid_foreign" FOREIGN KEY("playerId") REFERENCES "Player"("id");
ALTER TABLE
    "GameStats" ADD CONSTRAINT "gamestats_playerid_foreign" FOREIGN KEY("playerId") REFERENCES "Player"("id");
ALTER TABLE
    "RequestToJoinTeam" ADD CONSTRAINT "requesttojointeam_teamid_foreign" FOREIGN KEY("teamId") REFERENCES "Team"("id");
ALTER TABLE
    "Game" ADD CONSTRAINT "game_awayteamid_foreign" FOREIGN KEY("awayTeamId") REFERENCES "Team"("id");
ALTER TABLE
    "Game" ADD CONSTRAINT "game_hometeamid_foreign" FOREIGN KEY("homeTeamId") REFERENCES "Team"("id");
ALTER TABLE
    "PlayerOnTeamForSeason" ADD CONSTRAINT "playeronteamforseason_teamid_foreign" FOREIGN KEY("teamId") REFERENCES "Team"("id");
ALTER TABLE
    "PlayerOnTeamForSeason" ADD CONSTRAINT "playeronteamforseason_positionid_foreign" FOREIGN KEY("positionId") REFERENCES "Position"("id");
ALTER TABLE
    "PlayerOnTeamForSeason" ADD CONSTRAINT "playeronteamforseason_seasonid_foreign" FOREIGN KEY("seasonId") REFERENCES "Season"("id");
ALTER TABLE
    "Game" ADD CONSTRAINT "game_seasonid_foreign" FOREIGN KEY("seasonId") REFERENCES "Season"("id");
ALTER TABLE
    "RequestGame" ADD CONSTRAINT "requestgame_gameid_foreign" FOREIGN KEY("gameId") REFERENCES "Game"("id");
ALTER TABLE
    "GameStats" ADD CONSTRAINT "gamestats_gameid_foreign" FOREIGN KEY("gameId") REFERENCES "Game"("id");
ALTER TABLE
    "Team" ADD CONSTRAINT "team_coachid_foreign" FOREIGN KEY("coachId") REFERENCES "Coach"("id");
ALTER TABLE
    "RequestGame" ADD CONSTRAINT "requestgame_coachid_foreign" FOREIGN KEY("coachId") REFERENCES "Coach"("id");
ALTER TABLE
    "Coach" ADD CONSTRAINT "coach_userid_foreign" FOREIGN KEY("userId") REFERENCES "User"("id");
ALTER TABLE
    "RequestGame" ADD CONSTRAINT "requestgame_requeststatusid_foreign" FOREIGN KEY("requestStatusId") REFERENCES "RequestStatus"("id");
ALTER TABLE
    "Team" ADD CONSTRAINT "team_leagueid_foreign" FOREIGN KEY("leagueId") REFERENCES "League"("id");
ALTER TABLE
    "Game" ADD CONSTRAINT "game_gamestatusid_foreign" FOREIGN KEY("gameStatusId") REFERENCES "GameStatus"("id");
ALTER TABLE
    "Player" ADD CONSTRAINT "player_userid_foreign" FOREIGN KEY("userId") REFERENCES "User"("id");