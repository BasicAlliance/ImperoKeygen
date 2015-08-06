using System;
using System.Collections.Generic;

namespace ImperoKeygen
{
	public class WebCheckResponseModel
	{
		public string Status;
		public EndUserLicenceModel Licence;
		public FailureModel Failure;
	}

	public class EndUserLicenceModel
	{
		public string LicenceKey;
		public DateTime ExpirationDate;
		public Dictionary<string, string> Properties = new Dictionary<string, string> ();
		public List<ProductLicenceModel> Products = new List<ProductLicenceModel> ();
	}

	public class FailureModel
	{
		public string Code;
		public string Message;
	}

	public class ProductLicenceModel
	{
		public string Name;
		public string InternalKey;
		public string LicenceType;
		public string LicenceSubType;
		public DateTime ExpirationDate;
		public Dictionary<string, string> Properties = new Dictionary<string, string> ();
		public List<ModuleLicenceModel> Modules = new List<ModuleLicenceModel> ();
	}

	public class ModuleLicenceModel
	{
		public string Name;
		public string InternalKey;
		public List<FeatureLicenceModel> Features = new List<FeatureLicenceModel> ();
	}

	public class FeatureLicenceModel
	{
		public string InternalKey;
		public string Name;
		public List<FeatureLicenceModel> Features = new List<FeatureLicenceModel> ();
	}

	public enum ModuleFeatureType
	{
		AcceptableUsePolicy,
		ADLDAPControl,
		AdminTools,
		AdvancedPolicyESafety,
		AdvancedPolicyFull,
		AllowList,
		AssignTask,
		BlockList,
		Broadcast,
		ChangePasswords,
		CollectFiles,
		CommandPrompt,
		ComputerAvailability,
		ComputerManagement,
		Confide,
		CustomLockScreen,
		DeploySoftware,
		DisableAccounts,
		DisablePrinting,
		DisableUSB,
		EnableAccounts,
		EnhancedSecurity,
		EventViewer,
		FileSearch,
		Forum,
		Hibernate,
		InventoryViewer,
		KeywordList,
		LockGroup,
		LockInternet,
		LockUser,
		LockWorkStation,
		LogOff,
		LogOn,
		LogViewerFull,
		LogViewerViolation,
		Mimic,
		MuteSound,
		NewExam,
		OldExam,
		Patch,
		PersonnelGroups,
		PowerManagementAdmin,
		PowerOff,
		PowerOn,
		PrintCredit,
		QuickQuestion,
		RCAllowedToControl,
		RCTalk,
		RecordScreen,
		Restart,
		RoomBooking,
		RoomLayout,
		ScreenShot,
		SendFile,
		SendFileRunAs,
		SendMessage,
		SoftwareLicencing,
		Standby,
		TaskManager,
		Thumbnails,
		UnlockWorkStation,
		USBTracking,
		ViewConsoles,
		ViewWorkstations,
		WebsiteFile,
		WebsiteFileRunAs,
		YouID
	}
}
	