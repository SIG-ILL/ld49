using System.Collections.Generic;
using System.Text;
using UnityEngine;

public sealed class SituationGenerator : MonoBehaviour
{
	private const string PLAYER_CHARACTER_ROLE = "chief engineer";
	private const string PLAYER_CHARACTER_RANK = "lt. commander";
	private const string PLAYER_CHARACTER_RANK_SHORT = "commander";
	private const string PLAYER_CHARACTER_FIRST_NAME = "Feordi";
	private const string PLAYER_CHARACTER_SURNAME = "LaGorge";

	private List<string> materials;
	private List<string> machineFunctions;
	private List<string> machineParts;
	private List<string> defects;
	private List<string> playerCharacterIntroTitles;
	private List<string> introMotivations;
	private List<string> detectionSources;
	private List<string> imperativeCommands;
	
	private List<char> vowels;

	private void Awake() {
		materials = new List<string>() { "antimatter", "atmospheric", "atomic", "barometric", "darium", "dilithium", "energy", "gravitational", "ludarion", "magnetic", "matter", "phasic", "plasma", "quantum", "radiation", "roarum", "techyon", "tricyclic", "sonic", "subatomic", "subharmonic", "subspace", "temporal", "voltaic" };
		machineFunctions = new List<string>() { "absorption", "alignment", "amplitude", "anomaly", "balancing", "capacitive", "conductive", "confinement", "conversion", "containment", "delay", "dimensional", "distribution", "field", "interflux", "resistive", "realignment", "restraining", "shielding", "stabilization", "wave" };
		machineParts = new List<string>() { "absorber", "balancer", "beam", "capacitor", "chip", "coil", "compressor", "computer", "condenser", "conductor", "conduit", "container", "controller", "converter", "cooler", "crystal", "distributor", "engine", "exchanger", "generator", "inductor", "interface", "lock", "magnetizer", "manifold", "matrix", "overlay", "pressurizer", "radiator", "relay", "resistor", "shield", "sink", "stabilizer", "subsystem", "system", "transformer", "valve" };
		defects = new List<string>() { "breach", "collapse", "congestion", "cutoff", "deadlock", "defective part", "failure", "feedback loop", "interference", "leak", "malfunction", "overflow", "overload", "pressure decrease", "pressure increase", "race condition", "rift", "shutdown" };
		playerCharacterIntroTitles = new List<string>() { PLAYER_CHARACTER_ROLE, PLAYER_CHARACTER_ROLE + " " + PLAYER_CHARACTER_SURNAME, PLAYER_CHARACTER_RANK, PLAYER_CHARACTER_RANK + " " + PLAYER_CHARACTER_SURNAME, PLAYER_CHARACTER_RANK_SHORT, PLAYER_CHARACTER_FIRST_NAME, "Mr. " + PLAYER_CHARACTER_SURNAME };
		introMotivations = new List<string>() { "step it up", "be adviced", "new information", "I have a job for you", "good work so far", "keep it up", "hurry", "pay attention", "incoming data" };
		detectionSources = new List<string>() { "Our sensors are showing", "A crewmember reports", "The computer indicates", "Wurp core diagnostics revealed", "Complaints have been received about", "We are observing", "Our instruments seem to suggest" };
		imperativeCommands = new List<string>() { "Get to it!", "Save us!", "Help!", "Fix it!", "Keep us going for a little while longer!", "Please engineer a solution!", "Do something about it, will you?", "Work your magic!", "Let Engineering have a look at it!", "I trust I can leave this in your capable hands!" };

		vowels = new List<char>() { 'a', 'e', 'i', 'o', 'u' };
	}

	public EngineeringSituation GenerateSituation() {
		string machinePart = GenerateMachinePart();
		string defect = GenerateDefect();
		string situationIntro = GenerateIntro();
		string detectionSource = GenerateDetectionSource();
		string imperativeCommand = GenerateImperativeCommand();

		StringBuilder situationStringBuilder = new StringBuilder(situationIntro);
		situationStringBuilder.Append(" ");
		situationStringBuilder.Append(detectionSource);
		situationStringBuilder.Append(" a");
		if(vowels.Contains(defect[0])) { situationStringBuilder.Append("n"); }
		situationStringBuilder.Append(" ");
		situationStringBuilder.Append(defect);
		situationStringBuilder.Append(" in the ");
		situationStringBuilder.Append(machinePart);
		situationStringBuilder.Append(". ");
		situationStringBuilder.Append(imperativeCommand);

		string situationString = StartStringWithUpperCase(situationStringBuilder.ToString());
		EngineeringSituation situation = new EngineeringSituation {
			timeToFix = 10, defect = defect, defectivePart = machinePart, messageText = situationString,
			lowTimeEstimateOption = 2, mediumTimeEstimateOption = 4, highTimeEstimateOption = 8
		};

		return situation;
	}

	private string GenerateMachinePart() {
		bool addMaterial = Random.Range(0, 4) != 0;
		int materialIndex = Random.Range(0, materials.Count);
		int machineFunctionIndex = Random.Range(0, machineFunctions.Count);
		int machinePartIndex = Random.Range(0, machineParts.Count);

		string machinePartString = (addMaterial ? materials[materialIndex] + " " : "") + machineFunctions[machineFunctionIndex] + " " + machineParts[machinePartIndex];
		return machinePartString;
	}

	private string GenerateDefect() {
		int defectIndex = Random.Range(0, defects.Count);
		return defects[defectIndex];
	}

	private string GenerateIntro() {
		int playerCharacterTitleIndex = Random.Range(0, playerCharacterIntroTitles.Count);
		int motivationIndex = Random.Range(0, introMotivations.Count);

		string playerCharacterTitle = playerCharacterIntroTitles[playerCharacterTitleIndex];
		string motivation = introMotivations[motivationIndex];

		StringBuilder introBuilder = new StringBuilder(playerCharacterTitle);
		introBuilder.Append(", ");
		introBuilder.Append(motivation);
		introBuilder.Append("!");

		return introBuilder.ToString();
	}

	private string GenerateDetectionSource() {
		int detectionSourceIndex = Random.Range(0, detectionSources.Count);
		string detectionSource = detectionSources[detectionSourceIndex];
		return detectionSource;
	}

	private string GenerateImperativeCommand() {
		int imperativeCommandIndex = Random.Range(0, imperativeCommands.Count);
		string imperativeCommand = imperativeCommands[imperativeCommandIndex];
		return imperativeCommand;
	}

	private string StartStringWithUpperCase(string input) {
		return char.ToUpper(input[0]) + input.Substring(1);
	}
}
