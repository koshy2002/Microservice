# Microservice
Microservice  app is created based on the requirement from https://github.com/jwo/microservice-assessment <br/>
1.Open ScoreWebApi solution inside Microservice folder .</br>
2.This is the web api solution. Run this first.</br>
3.Open ScoreClient solution inside Microservice folder.</br>
4.Run the ScoreClinet solution.</br>
</br> </br>

Please note :- Make sure the web api solution is running .Webapi is in ScoreWebApi folder.ScoreClient takes data from WebApi.

</br>
GET : http://localhost:55641/api/leaderboard </br>
RESPONSE BODY : Return all the Leaderboard</br></br>

GET : http://localhost:55641/api/leaderboard/[:id] </br>
RESPONSE BODY : Return Leaderboard of particular id </br></br>

POST : http://localhost:55641/api/leaderboard/reset</br>
OUTPUT : Clears data from Leaderboard and Match</br></br>

GET: http://localhost:55641/api/match</br>
RESPONSE BODY : Return all the match</br></br>

POST : http://localhost:55641/api/match</br>
REQUEST BODY :  {player: [player name], level: [level], opponentName:[opponent name] opponentLevel: [opponent level]} </br>
RESPONSE BODY: Return all the match</br></br>

PUT : http://localhost:55641/api/match/[:id]</br>
REQUEST BODY : { "status": "complete",  "winner": [winner name] } </br>
RESPONSE BODY : updates the winner
