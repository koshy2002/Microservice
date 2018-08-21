# Microservice
Microservice  app is created based on the requirement from https://github.com/jwo/microservice-assessment <br/>
1.Open ScoreWebApi solution inside Microservice folder .</br>
2.This is the web api solution written in Asp.Net Core Web Api. Run this first.</br>
3.Open ScoreClient solution inside Microservice folder. This is written in Asp.Net Core MVC</br>
4.Run the ScoreClient solution.</br>
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
RESPONSE BODY : updates the winner  </br> </br>
<b> Screen 1 </b> </br>
<img width="950" alt="1" src="https://user-images.githubusercontent.com/42551395/44413187-f1923a80-a527-11e8-8d87-0c5537631937.png"> 
</br><b> Screen 2 </b> </br>
<img width="951" alt="2" src="https://user-images.githubusercontent.com/42551395/44413288-446bf200-a528-11e8-8edb-352756b5864c.png">
</br></br><b> Screen 3 </b> </br>
<img width="945" alt="3" src="https://user-images.githubusercontent.com/42551395/44413384-75e4bd80-a528-11e8-88e6-d894d5c34638.png">

