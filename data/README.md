## How to download sudokus


https://sudoku-api.vercel.app/api/dosuku is a sudoku generator.  Hitting twice
the api returns two different sudokus.

The below command is will download a soduko and persist it to the
`sudoku_099.json` file.

````shell
 curl https://sudoku-api.vercel.app/api/dosuku -o sudoku_099.json
``````