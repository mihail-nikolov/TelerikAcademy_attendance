	function solve(args){
		var s = +args[0];
		var count = 0;
		//console.log(s);
		for (var i = 0; i <= s; i++) {
			for (var j = 0; j < s; j++) {
				for (var k = 0; k < s; k++) {
					if (10*k + 4*j + 3*i == s) 
					{
						count ++;
					};
				};
			};
		};

		console.log(count);
	}

solve(['40']);


function solve1(args){
	var s = +args[0];
	var c1 = +args[1];
	var c2 = +args[2];
	var c3 = +args[3];
	var biggest = 0;

	for (var i = 0; i < s/c1 +1; i++) {
		for (var j = 0; j < s/c2+1;j++) {
			for (var k = 0; k < s/c3+1; k++) {
				var current = i*c1 + j*c2 + k*c3;
				if (current <= s && current > biggest) {
					biggest = current;
				} 
			};
		};
	};
	console.log(biggest);
}

solve1(['110','13','15','17']);


function solve2(args){

	var rowsCols = args[0].split(' ');
	var rows = rowsCols[0];
	var cols = rowsCols[1];
	//return rows + ',' + cols;
	var matrix = args.slice(1).map(function(line){
		return line.split(' ');
	})
	//return matrix;
	var row = 0;
	var col = 0;
	var sum = 0;
	var directions = {
		d: +1,
		u: -1,
		l: -1,
		r: +1

	}
	var LR;
	var UD

	// row += directions[matrix[row][col][0]];
	// return row;

	while(true){
		if (row < 0 || row >= rows || col < 0 || col >= cols) {
			return "successed with "+sum;
		};

		if (matrix[row][col] === 'used') {
			return "failed at (" +row+", "+col + ")";
		}

		sum += Math.pow(2, row) + col;

		UD = directions[matrix[row][col][0]];
		LR = directions[matrix[row][col][1]];

		matrix[row][col] = 'used';

		row += UD;
		col += LR;


	}

}

tests = [
	[
	  '3 5',
	  'dr dl dr ur ul',
	  'dr dr ul ur ur',
	  'dl dr ur dl ur'   
	]
	,
	[
	  '3 5',
	  'dr dl dl ur ul',
	  'dr dr ul ul ur',
	  'dl dr ur dl ur'   
	]
]

tests.forEach(function(test){
	console.log(solve2(test));
});