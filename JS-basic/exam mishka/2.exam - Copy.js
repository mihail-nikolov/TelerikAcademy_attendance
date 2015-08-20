





function solve(params) {


//-----------------------------------------------------------------------------------------------------
    Array.prototype.contains = function(k) {
      for(var i=0; i < this.length; i++){
        if(this[i].toString() == k.toString()){
          return true;
        }
      }
      return false;
    }


    function isValidKnightMove(current, will, allowedKnightCoords){
            var knightMoveCoords = [];
            knightMoveCoords[0] = current[0] - will[0];
            knightMoveCoords[1] = current[1] - will[1];
            if (allowedKnightCoords.contains(knightMoveCoords)){
                return true;
            }
            return false;
        }



    function isCellisFree(coords, board){

        if (board[coords[0]][coords[1]] == '-') {
            return true;
        };
        return false;

    }

    function convertCoords(cCoords, rows){

        var coords = [];
            //parsedCCoords = cCoords.split(' ');
        coords[1] = cCoords.charCodeAt(0) - 97;
        coords[0] = Math.abs(+cCoords[1] - rows);
        return coords;
    }

    function isValidQueenMove(current, will, board){
        if(current[0] == will[0] && current[1] >= will[1]){
            for (var i = current[1]; i <= will[1]; i++) {
                if (board[current[0]][i] != '-') {
                    return false;
                };
            };
            return true; //movement in a straight line;
        }
        if(current[0] == will[0] && current[1] <= will[1]){
            for (var i = will[1]; i <= current[1]; i++) {
                if (board[current[0]][i] != '-') {
                    return false;
                };
            };
            return true; //movement in a straight line;
        }

        if(current[1] == will[1] && current[0] <= will[0]){
            for (var i = will[1]; i <= current[1]; i++) {
                if (board[i][current[1]] != '-') {
                    return false;
                };
            };
            return true; //movement in a straight line;
        }

        if(Math.abs(current[0] - will[0]) == Math.abs(current[1] - will[1])){
            
            var bigger_diag1 = Math.max(current[0], will[0])
            var smaller_diag1 = Math.min(current[0], will[0])
            var bigger_diag2 = Math.max(current[1], will[1])
            var smaller_diag2 = Math.min(current[1], will[1])

            for (var i = smaller_diag1; i <= bigger_diag1; i++) {
                for (var j = smaller_diag2; j <= bigger_diag2; j++) {
                    var newI = smaller_diag1 + i;
                    var newJ = smaller_diag2 + j;
                    if(Math.abs(current[0] + newI) == Math.abs(current[1] + newJ)){
                        if (board[newI][newJ] != '-') {
                            return false;
                        };
                    };
                }
            }
            return true;
        }
        return false;
    }

    var knightMoves = [[-2, 1], [-1, 2], [1, 2], [2, 1],
                        [2, -1], [1, -2], [-1, -2], [-2, -1]];
    var rows = parseInt(params[0]),
        cols = parseInt(params[1]),
        tests = parseInt(params[rows + 2]),
        i, move,
        board = [];
    for (var i = 2; i < 2 + rows; i++) {
    	board.push(params[i].split(''));
    }

//-----------------------------------------------------------------------------------------------------


    //console.log(board);

    for (i = 0; i < tests; i++) {
        move = params[rows + 3 + i];
        var parsedCoords = move.split(' ');
        var current = convertCoords(parsedCoords[0], rows);
        var will  = convertCoords(parsedCoords[1], rows);

        if (!isCellisFree(will, board)) {
        	console.log('no');
        } 

        else if (board[current[0]][current[1]] == 'Q') {

        	if(isValidQueenMove(current, will, board)){
        		console.log('yes')
        		//console.log('yes --> ' + board[current[0]][current[1]] + " current " + current + " will: " + will );
        	}
        	else{
        		console.log('no')
        		//console.log('no --> ' + board[current[0]][current[1]] + " current " + current + " will: " + will );
        	}

        }

        else if (board[current[0]][current[1]] == 'K') {

        	if(isValidKnightMove(current, will, knightMoves)){
        		console.log('yes')
        		//console.log('yes --> ' + board[current[0]][current[1]] + " current" + current + " will: " + will );
        	}
        	else{
        		console.log('no')
        		//console.log('no --> ' + board[current[0]][current[1]] + " current" + current + " will: " + will );
        	}

        }
        else{
        	console.log('no');
        }
    }
}

//solve([3, 4, '--K-', 'K--K', 'Q--Q', 12,'d1 b3', 'a1 a3', 'c3 b2', 'a1 c1', 'a1 b2', 'a1 c3', 'a2 c1', 'd2 b1', 'b1 b2', 'c3 a3', 'a2 a3', 'd1 d3']);
//solve([5, 5, 'Q---Q', '-----', '-K---','--K--', 'Q---Q', 10,'a1 a1','a1 d4', 'e1 b4', 'a5 d2', 'e5 b2', 'b3 d4', 'b3 c1', 'b3 d1', 'c2 a3', 'c2 b4']);

