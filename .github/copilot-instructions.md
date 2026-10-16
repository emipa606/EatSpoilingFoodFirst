# GitHub Copilot Instructions for RimWorld Modding Project: Eat Spoiling Food First (Continued)

## Mod Overview and Purpose

**Mod Name:** Eat Spoiling Food First (Continued)  
**Mod Description:**  
This mod aims to improve the AI behavior of pawns in RimWorld by encouraging them to consume food items that are closer to spoiling. In the base game, the default `FoodOptimality` calculations often lead to freshly prepared or younger food items being eaten first, while items that are close to spoilage are ignored. This can lead to waste, as food that could have been consumed goes bad. This mod alters `FoodOptimality` to apply a linear spoilage-based bonus, ensuring that pawns choose to eat food items that are about to spoil whenever possible. The changes apply to both humans and player-controlled animals.

## Key Features and Systems

- **Spoilage Awareness:** Modifies food selection logic to prefer items closer to their spoilage time.
- **Linear Bonus:** Applies a linear bonus to `FoodOptimality` based on how soon a food item will spoil.
- **Target Audience:** Only affects human pawns and player-controlled animals, maintaining the game's intended difficulty for wildlife and enemy factions.
- **Minimal Impact on Existing Mechanics:** Adjustments are designed to seamlessly integrate with existing game mechanics, keeping distance and other factors as prominent considerations.

## Coding Patterns and Conventions

### C# File Structure
- Files: 
  - `FoodUtility_FoodOptimality.cs`
  - `EatSpoilingFoodFirst.cs`
- Follow C# naming conventions: 
  - Classes and methods in PascalCase.
  - Use descriptive names for variables and methods to enhance readability.
- Maintain consistently formatted comments to document functionality for future maintenance and collaboration.

### XML Integration
- The `About.xml` file is crucial for defining mod metadata, such as dependencies (e.g., `brrainz.harmony`).
- Ensure XML tags are properly closed, and follow a hierarchical structure to maintain readability and reduce errors.

## Harmony Patching

### Overview
- **Harmony Dependency:** This mod relies on the Harmony library to patch the game's core method of food selection logic.
- **Postfix Usage:** Utilizes a `Postfix` method on the `FoodOptimality` calculation to adjust the spoilage bonus after the original logic executes.

### How to Work with Harmony
- Always begin by importing Harmony libraries at the top of your C# files.
- Define a `Postfix` method if additional logic is needed after the base game method executes.
- Use careful consideration to affect only required classes and methods to avoid unintended side effects.

## Suggestions for Copilot

- **Unit Test Generation:** Use Copilot to create unit tests to ensure that modifications do not introduce errors or conflicts with other mods.
- **Refactoring Suggestions:** Leverage Copilot to provide refactoring suggestions that can lead to more efficient code or improve readability.
- **Auto-completion:** Utilize Copilot for suggested code completion in repetitive tasks, such as pattern implementation or predictable logic.

With these guidelines, you can use GitHub Copilot to effectively collaborate and maintain the **Eat Spoiling Food First (Continued)** mod for RimWorld. By adhering to these practices, both the organization of code and the maintainability of the project will be significantly enhanced.

## Project Solution Guidelines
- Relevant mod XML files are included as Solution Items under the solution folder named XML, these can be read and modified from within the solution.
- Use these in-solution XML files as the primary files for reference and modification.
- The `.github/copilot-instructions.md` file is included in the solution under the `.github` solution folder, so it should be read/modified from within the solution instead of using paths outside the solution. Update this file once only, as it and the parent-path solution reference point to the same file in this workspace.
- When making functional changes in this mod, ensure the documented features stay in sync with implementation; use the in-solution `.github` copy as the primary file.
- In the solution is also a project called Assembly-CSharp, containing a read-only version of the decompiled game source, for reference and debugging purposes.
- For any new documentation, update this copilot-instructions.md file rather than creating separate documentation files.


## Hard rules (must follow)
- Do NOT run commands that modify the repo (no git commit, git apply, dotnet format) unless explicitly asked.
- Prefer minimal reads: read only the smallest code region needed (around the suspicious lines).
- When mentioning SonarQube issues, automatically use the SonarQube MCP service to fetch and address issues instead of making inferred fixes without querying SonarQube first.
- When mentioning the rimworld log, automatically use the Rimworld MCP service to fetch the log.

