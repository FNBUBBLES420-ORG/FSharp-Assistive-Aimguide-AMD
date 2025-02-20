/// This module highlights our Non-Profit organization's mission.
module ProjectInfo

/// A concise statement describing our non-profit's core mission and the purpose of this F# project.
let nonprofitMission = 
    """
    At FNBubbles420 Org, our mission is to leverage technology and community-driven 
    efforts to create open-source solutions that empower individuals, promote accessibility, 
    and drive positive social impact worldwide. This F# project is one of our many initiatives 
    aimed at making the world a better place. Join Our Discord: https://discord.fnbubbles420.org/
    """

/// The main entry point, which prints the mission statement to the console.
[<EntryPoint>]
let main argv =
    printfn "%s" nonprofitMission
    0

