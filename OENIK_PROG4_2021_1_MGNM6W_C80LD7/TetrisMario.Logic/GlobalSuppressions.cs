// <copyright file="GlobalSuppressions.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using System.Diagnostics.CodeAnalysis;

[assembly: SuppressMessage("", "CA1014", Justification = "<NikGitStats>", Scope = "module")]
[assembly: SuppressMessage("Security", "CA5394:Do not use insecure randomness", Justification = "<pendinga>", Scope = "member", Target = "~M:GameLogic.MarioTetrisLogic.SpawnBlock")]
[assembly: SuppressMessage("Security", "CA5394:Do not use insecure randomness", Justification = "<Random>", Scope = "member", Target = "~M:TetrisMario.Logic.GameLogic.SpawnBlock")]
[assembly: SuppressMessage("Security", "CA5394:Do not use insecure randomness", Justification = "idk", Scope = "member", Target = "~M:TetrisMario.Logic.GameLogic.Update")]
[assembly: SuppressMessage("Design", "CA1062:Validate arguments of public methods", Justification = "idk", Scope = "member", Target = "~M:TetrisMario.Logic.GameLogic.Shoot(TetrisMario.Model.Player)~System.Boolean")]
