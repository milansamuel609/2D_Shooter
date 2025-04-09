**<H1>1. What Is This Game All About ?</H1>**

- Player Control: The player controls a character (represented by a blue sprite) using the arrow keys or "WASD". The character can move in 2D space but cannot rotate. The character also has an explosion ability to attack enemies.
- Enemies: Red enemy units are scattered across the battlefield. They have AI that makes them chase the player when within a detection range. They also speed up when closer to the player.
- Explosions: The player has the ability to cause explosions, which are triggered when the player collides with an enemy. The explosion deals damage to enemies and provides a reward (score).
- Shooting Mechanism: The player can shoot bullets at enemies. When a bullet hits an enemy, the enemy is destroyed, and the player gains points. A bullet can be fired by pressing the left mouse button.
- Scoring: The player earns points by destroying enemies. The game keeps track of the score, which is displayed on the screen. The final score is shown at the end of the game.
- Game Over & Restart: If the player collides with an enemy, the game ends, and a "Game Over" screen appears, showing the player's final score. The player can restart the game by pressing the 'R' key.
- Win Condition: The game is won if all enemies are destroyed. A win screen appears, showing the final score.
- Visual Effects: Explosion effects are used when enemies are destroyed or when the player causes an explosion. These effects grow and fade over time.

**<H1>2. How DevOps Works in This Game</H1>**

In this game, here’s how a typical DevOps pipeline (using GitHub Actions, Docker, and Unity) works:

**a. Code Changes (Commit/Push)**

- Developers work on the game code and make changes, such as adding new features, fixing bugs, or optimizing gameplay.
- The code is pushed to the repository, making it easy to manage and update.

**b. CI Process**

- Automatic Testing: When new code is pushed, the CI pipeline automatically triggers the following steps:
- The game is built using Unity's headless mode (with Unity Editor).
- Unit tests (such as those run by the Unity Test Runner) are automatically executed.
- If there are any issues (e.g., failing tests), the build is rejected, and the development team is notified.

**c. Docker and Build Containers**

- Docker containers are used to create isolated environments for building and testing the game.
- By running the Unity build in Docker, you ensure that the environment is consistent, no matter where the code is built (local dev machine, CI servers, or production).
- The containerized builds prevent issues that arise from "works on my machine" scenarios, where the game might build on one machine but fail on another due to environment differences.

**d. Continuous Deployment**

- Once the game passes all tests, the CI pipeline automatically triggers the CD pipeline. This means:
- The game is built for specific platforms, such as WebGL, Windows, Mac, or Android, depending on your configuration.
- The built game (or the latest WebGL version) is uploaded to an artifact server or directly to a cloud platform (e.g., AWS S3, Azure Blob Storage).
- The game is ready to be served to end-users.

**e. Real-Time Updates**

- With a CI/CD pipeline, new updates can be deployed automatically as soon as they’re ready, without requiring manual intervention.
- This allows your game to be updated much more frequently and efficiently.

**<H1>3. User Benefits:</H1>**

- Faster Game Updates: Players get immediate access to bug fixes, new features, and optimizations without the hassle of manually downloading updates.
- Less Downtime: Since the CI/CD pipeline runs behind the scenes, there’s less downtime when new updates are rolled out. Players can continue playing with minimal disruptions.
- Better Game Stability: With automated testing integrated into the CI/CD process, the risk of bugs or broken builds being released is minimized, leading to a more stable experience for the users.

<br>

**<H1>Game Screenshots</H1>**

![image](https://github.com/user-attachments/assets/6d2d5890-d076-454a-a0c4-fb2e0084ef36)

![image](https://github.com/user-attachments/assets/eac8ee47-111c-40cc-a90a-199574b0bbb6)

![image](https://github.com/user-attachments/assets/1e34e31f-ea66-4e67-a914-129ec37654c8)

![image](https://github.com/user-attachments/assets/5932ec8c-b349-4b72-ab81-c3b48dc619eb)

**The Game Is Sooner Going Live On [itch.io](https://itch.io/). Stay Tuned !!**

**Developed By : Milan P Samuel**
