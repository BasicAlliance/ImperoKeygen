using System;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace ImperoKeygen
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			Console.WriteLine ("Impero Server (<=5104) Keygen written by Komodo");
			Console.WriteLine ("gg no re impero");
			Console.WriteLine ();

			Console.WriteLine ("Below, enter the activation code you specified. An offline 'key' will be generated.");
			Console.WriteLine ();
			Console.Write ("Activation Code: ");
			string activationCode = Console.ReadLine ();

			WebCheckResponseModel webCheckModel = new WebCheckResponseModel ();
			webCheckModel.Status = "success";

			EndUserLicenceModel endUserLicense = new EndUserLicenceModel ();

			endUserLicense.LicenceKey = activationCode;
			endUserLicense.ExpirationDate = DateTime.Parse ("9999-12-25T23:59:59");

			endUserLicense.Properties.Add ("RegistrationDate", "");
			endUserLicense.Properties.Add ("EstablishmentName", "LizardHQ");
			endUserLicense.Properties.Add ("AccessPassword", "password");
			endUserLicense.Properties.Add ("LatestServerVersionAllowed", "5104");
			endUserLicense.Properties.Add ("LatestClientVersionAllowed", "5104");
			endUserLicense.Properties.Add ("MaximumWorkstations", Int32.MaxValue.ToString ());
			endUserLicense.Properties.Add ("MaximumConsoles", Int32.MaxValue.ToString ());
			endUserLicense.Properties.Add ("LatestServerCRC", "");
			endUserLicense.Properties.Add ("LatestClientCRC", "");
			endUserLicense.Properties.Add ("LatestClientZipCRC", "");
			endUserLicense.Properties.Add ("LatestClientMACZipCRC", "");

			{
				ProductLicenceModel productModel = new ProductLicenceModel ();
				productModel.ExpirationDate = DateTime.Parse ("9999-12-25T23:59:59");
				productModel.Name = "LizardHQ_PREMIUM_License";
				productModel.InternalKey = "EducationPro";
				productModel.LicenceType = "Full";
				productModel.LicenceSubType = "EducationPro";

				{
					ModuleLicenceModel moduleModel = new ModuleLicenceModel ();
					moduleModel.Name = "LizardHQ";
					moduleModel.InternalKey = "Server";

					ModuleFeatureType[] featureList = ((ModuleFeatureType[])Enum.GetValues (typeof(ModuleFeatureType)));

					foreach (ModuleFeatureType feature in featureList)
					{
						FeatureLicenceModel featureModel = new FeatureLicenceModel ();
						featureModel.InternalKey = feature.ToString ();
						featureModel.Name = feature.ToString ();
						//Console.WriteLine ("Adding feature " + featureModel.Name);
						moduleModel.Features.Add (featureModel);
					}

					productModel.Modules.Add (moduleModel);
				}

				endUserLicense.Products.Add (productModel);
			}

			webCheckModel.Licence = endUserLicense;

			string license = JsonConvert.SerializeObject (webCheckModel);
			string encrypted = ImperoCrypt.EncryptRijndael (license, "1E.BA4!P356TbvdLNky_2D=HF");
			Console.WriteLine (encrypted);
			Console.ReadLine ();
		}
	}
}