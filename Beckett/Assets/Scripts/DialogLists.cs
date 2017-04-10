using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 /// <summary>
 /// Dialog controller. Lists of dialog divided to zones.
 /// </summary>
public class DialogLists {

	List<string> dialogMarketplace = new List<string>();
	List<string> dialogDocks = new List<string>();

	/// <summary>
	/// Adds all the dialog options to lists.
	/// </summary>
	public void AddDialog(){
		//Beckett says this everytime he speaks to someone in the marketplace
		dialogMarketplace.Add ("Did you see anything useful last night?");
		//Next 4 dialogs are options for npc's to say
		dialogMarketplace.Add ("I saw the pirates splitting into smaller groups.");
		dialogMarketplace.Add ("I didn't see anything.");
		dialogMarketplace.Add ("I hid behind the counter the whole time.");
		dialogMarketplace.Add ("Most of the pirates went the same way.");
		//Beckett says this to end the conversations
		dialogMarketplace.Add ("Thank you for the information.");

		//Dockmaster says this when Beckett goes to speak with him
		dialogDocks.Add ("The ship was damaged by cannons, Captain, you need to gather supplies to repair it.");
		//Beckett asks what he needs
		dialogDocks.Add ("What supplies do I need?");
		//Dockmaster tells what is needed for ship's repair
		dialogDocks.Add ("You need wood, metal and sail fabric.");
		//And where to find them
		dialogDocks.Add ("You can gather these from nearby islands.");
		//Beckett says either one based on where the player decides to go first
		dialogDocks.Add ("I will head to Volcano Island first!");
		dialogDocks.Add ("I will head to Jungle Island first!");


	}











}
