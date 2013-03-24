using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyPopcorn
{
    class AcademyPopcornMain
    {
        const int WorldRows = 23;
        const int WorldCols = 40;
        const int RacketLength = 6;

        static void Initialize(Engine engine)
        {
            int startRow = 3;
            int startCol = 2;
            int endCol = WorldCols - 2;

            for (int i = startCol; i < endCol; i++)
            {
                Block currBlock = new Block(new MatrixCoords(startRow, i));

                engine.AddObject(currBlock);
            }

            ExplodingBlock explodingBlock = new ExplodingBlock(new MatrixCoords(4,7));
            engine.AddObject(explodingBlock);
            //Ball theBall = new Ball(new MatrixCoords(WorldRows / 2, 0),
            //    new MatrixCoords(-1, 1));

            //engine.AddObject(theBall);

            //MeteoriteBall meteroitBall = new MeteoriteBall(new MatrixCoords(WorldRows / 2, 0),
            //    new MatrixCoords(-1, 1));

           // engine.AddObject(meteroitBall);

            UnstoppableBall unstoppableBall = new UnstoppableBall(new MatrixCoords(WorldRows / 2, 0),
                new MatrixCoords(-1, 1));
            engine.AddObject(unstoppableBall);

            UnpassableBlock unpassableBlock = new UnpassableBlock(new MatrixCoords(15, 15));
            engine.AddObject(unpassableBlock);
            UnpassableBlock unpassableBlock1 = new UnpassableBlock(new MatrixCoords(15, 16));
            engine.AddObject(unpassableBlock1);
            UnpassableBlock unpassableBlock2 = new UnpassableBlock(new MatrixCoords(15, 17));
            engine.AddObject(unpassableBlock2);

            Racket theRacket = new Racket(new MatrixCoords(WorldRows - 1, WorldCols / 2), RacketLength);

            engine.AddObject(theRacket);

            //Racket secondRacket = new Racket(new MatrixCoords(WorldRows -10, WorldCols / 2), RacketLength);

           // engine.AddObject(secondRacket);

            TrailObject trailObject = new TrailObject(new MatrixCoords(1, 1), 20);

            engine.AddObject(trailObject);

            for (int i = 0; i < WorldRows; i++)
            {
                IndestructibleBlock indestructibleBlockLeft = new IndestructibleBlock(new MatrixCoords(i,0));
                IndestructibleBlock indestructibleBlockRight = new IndestructibleBlock(new MatrixCoords(i, WorldCols-1));
                engine.AddObject(indestructibleBlockLeft);
                engine.AddObject(indestructibleBlockRight);
            }

            for (int i = 0; i < WorldCols; i++) {
                IndestructibleBlock indestructibleBlockCeiling = new IndestructibleBlock(new MatrixCoords(0, i));
                engine.AddObject(indestructibleBlockCeiling);
            }

            
        }

        static void Main(string[] args)
        {
            IRenderer renderer = new ConsoleRenderer(WorldRows, WorldCols);
            IUserInterface keyboard = new KeyboardInterface();

            Engine gameEngine = new Engine(renderer, keyboard,300);

            keyboard.OnLeftPressed += (sender, eventInfo) =>
            {
                gameEngine.MovePlayerRacketLeft();
            };

            keyboard.OnRightPressed += (sender, eventInfo) =>
            {
                gameEngine.MovePlayerRacketRight();
            };

            Initialize(gameEngine);

            //

            gameEngine.Run();
        }
    }
}
