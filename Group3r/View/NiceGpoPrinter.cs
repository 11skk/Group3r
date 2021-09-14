﻿using LibSnaffle.ActiveDirectory;
using Group3r.Assessment;
using System.Collections.Generic;
using System.Text;

namespace Group3r.View
{
    /**
     * Summary: Implementation of IGpoOutputter which just returns nice GPO output.
     */
    class NiceGpoPrinter : IGpoPrinter
    {
        /**
         * Summary: constructor
         * Arguments: none
         * Returns: NiceGpoPrinter instance
         */
        public NiceGpoPrinter()
        {
            // set up the printer
        }


        /**
         * Summary: Implementation of OutputGPO which returns the GPO as a nice string.
         * Arguments: GPO object to be outputted
         * Returns: string representation of GPO
         */
        public string OutputGPO(GPO gpo)
        {
            string gpoString = "";
            return gpoString;
        }

        public string OutputGpoResult(GpoResult gpoResult)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine();
            sb.AppendLine("-------------------------------");
            string morphed = "Current";
            if (gpoResult.Attributes.IsMorphedGPO)
            {
                morphed = "Morphed";
            }
            string gpoDisplayName = gpoResult.Attributes.DisplayName;
            if (string.IsNullOrWhiteSpace(gpoDisplayName))
            {
                gpoDisplayName = "(No Display Name)";
            }
            sb.AppendFormat("{0} - {1} - {2}", gpoResult.Attributes.DisplayName, gpoResult.Attributes.Uid, morphed);
            sb.AppendLine();
            sb.AppendLine("-------------------------------");
            sb.AppendFormat("Date Created: {0}", gpoResult.Attributes.CreatedDate);
            sb.AppendLine();
            sb.AppendFormat("Date Modified: {0}", gpoResult.Attributes.ModifiedDate);
            sb.AppendLine();
            sb.AppendFormat("Path in SYSVOL: {0}", gpoResult.Attributes.PathInSysvol);
            sb.AppendLine();
            string computerPolicy = "Disabled";
            string userPolicy = "Disabled";
            if (gpoResult.Attributes.ComputerPolicyEnabled)
            {
                computerPolicy = "Enabled";
            }
            if (gpoResult.Attributes.UserPolicyEnabled)
            {
                userPolicy = "Enabled";
            }
            sb.AppendFormat("Computer Policy: {0}", computerPolicy);
            sb.AppendLine();
            sb.AppendFormat("User Policy: {0}", userPolicy);
            sb.AppendLine();
            foreach (GPOLink gpoLink in gpoResult.Attributes.GpoLinks)
            {
                sb.AppendFormat("Link: {0} ({1})", gpoLink.LinkPath, gpoLink.LinkEnforced);
                sb.AppendLine();

            }
            sb.AppendLine("-------------------------------");
            if (gpoResult.GpoAttributeFindings.Count >= 1)
            {
                // write GpoAttributeFindings
            }
            sb.AppendLine("-------------------------------");
            if (gpoResult.GpoAclResult.Count >= 1)
            {
                //write gpo ACL results
            }
            sb.AppendLine("-------------------------------");

            foreach (SettingResult sr in gpoResult.SettingResults)
            {
                if (sr.Setting.GetType() == typeof(DataSourceSetting)){

                }

            }

            /*
___________________
$SettingType Finding - {Red}
~~~~~~~~~~~~~~~~~~~
Reason: $REASON
Detail: $DETAIL

Setting Prop1:
Setting Prop2:

___________________
$SettingType
~~~~~~~~~~~~~~~~~~~
Setting Prop1:
Setting Prop2:
*/


            return sb.ToString();
        }
    }
}