public sealed class EngineeringSituation {
	public float timeNeededToFix;
	public float timeUntilWurpCoreDamage;
	public string defect;
	public string defectivePart;
	public string messageText;

	public int lowTimeEstimateOption;
	public int mediumTimeEstimateOption;
	public int highTimeEstimateOption;
}

public sealed class OngoingEngineeringSituation {
	public EngineeringSituation situation;
	public float timeOfFixCompletion;
	public float timeOfWurpCoreDamage;
	public float playerEstimationOfTimeOfFixCompletion;
	public bool hasCausedStress;
	public bool hasCausedWurpCoreDamage;
}