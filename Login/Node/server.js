var mysql = require('mysql');

var express = require('express')
var app = express()

var con = mysql.createConnection({
  host: "localhost",
  user: "root",
  password: "rootpassword",
  database: "heka"
});
/*
con.connect(function(err) {
  if (err) throw err;
  console.log("Connected!");
});
*/
con.connect(function(err) {
  if (err) throw err;
  console.log("Connected!");
  con.query("SELECT * FROM login", function (err, result) {
    if (err) throw err;
    console.log("Result: " + result);
	
	var len = result.length;
	for ( var i = 0; i < len; i++ ){
		console.log(result[i].name)
	}
	
	app.get('/', function (req, res) {
  res.send('hello world')
})

	app.get('/users', function (req, res) {
	  //res.write('connected!\n');
	  /*
		for ( var i = 0; i < len; i++ ){
			res.write(result[i].name + '\n')
		}
		*/
		
		//https://www.nuget.org/packages/Newtonsoft.Json/6.0.3
		
		res.setHeader('Content-Type', 'application/json');
		res.write(JSON.stringify(result))
		res.end()
})
	/*
	http.createServer(function (req, res) {
	  res.writeHead(200, {'Content-Type': 'text/plain'});
	  res.write('connected!\n');
	  
		for ( var i = 0; i < len; i++ ){
			res.write(result[i].name + '\n')
		}
	  
	  res.end();
	}).listen(8080); 
	*/
	
	app.listen(8080, () => console.log(`Example app listening on port ${8080}!`))
	//con.end()
	
  });
}); 