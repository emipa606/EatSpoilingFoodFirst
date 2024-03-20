# EatSpoilingFoodFirst

![Image](https://i.imgur.com/buuPQel.png)

Update of nath_devs mod https://steamcommunity.com/sharedfiles/filedetails/?id=2830119751

![Image](https://i.imgur.com/pufA0kM.png)

	
![Image](https://i.imgur.com/Z4GOv8H.png)

Raging at your pawn eating the freshly cooked meal instead of the stack of spoiling in 1 hour meals ?
Drinking the fresh beers and letting the old ones rot ?

This mod fix this for you by making the pawns eat the most spoiled food first.

Details:

In vanilla Rimworld, what determine if a food is going to get eaten is a value called FoodOptimality (higher the better) and a small constant bonus modifier is applied if a food is going to spoils in less than 12h.

Meaning that a food spoiling in 1 hour has the same value than a food spoiling in 11h (same for 1 day and 3 days).

This mod cancel the vanilla logic and compute the FoodOptimality bonus modifier for spoiling food in a linear fashion according to remaining spoiling time (closest to fully spoiled gets more bonus).

The linear bonus is applied if a food is going to spoiled in less than 3 days and only applies on humans and player animals.

Technicality:

FoodOptimality value is computed according to distance between pawn and food modifier, food mood modifier, food nutrition modifier, ect (distance modifier has the greatest impact).

I've designed the linear spoil modifier to only have on small impact on the FoodOptimality algorithm.
That's means for example that between a 50 tile spoiling food and a really close fresh food, the linear spoil modifier will be negated by the distance modifier.

Mod dependencies : Harmony

Github : https://github.com/nathtest/EatSpoilingFoodFirst

Other mod : 
- Caravan Auto Food Restrictions : https://steamcommunity.com/sharedfiles/filedetails/?id=2792347147

![Image](https://i.imgur.com/PwoNOj4.png)



-  See if the the error persists if you just have this mod and its requirements active.
-  If not, try adding your other mods until it happens again.
-  Post your error-log using https://steamcommunity.com/workshop/filedetails/?id=818773962]HugsLib or the standalone https://steamcommunity.com/sharedfiles/filedetails/?id=2873415404]Uploader and command Ctrl+F12
-  For best support, please use the Discord-channel for error-reporting.
-  Do not report errors by making a discussion-thread, I get no notification of that.
-  If you have the solution for a problem, please post it to the GitHub repository.
-  Use https://github.com/RimSort/RimSort/releases/latest]RimSort to sort your mods



https://steamcommunity.com/sharedfiles/filedetails/changelog/3092186754]![Image](https://img.shields.io/github/v/release/emipa606/EatSpoilingFoodFirst?label=latest%20version&style=plastic&color=9f1111&labelColor=black)

