﻿// -------------------------------------------------------
// Automatically generated with Kodeo's Reegenerator for NON-COMMERCIAL USE
// Generator: RgenTemplate (internal)
// Generation date: 2018-02-03 08:15
// Generated by: PC\gedda
//-------------------------------------------------------
namespace RenderersLibrary
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Reegenerator", "2.0.17.0")]
    [Kodeo.Reegenerator.Generators.TemplateDisplayAttribute(DisplayName="Seasons", Description="Seasons", HideInDialog=false)]
    public partial class Seasons : Kodeo.Reegenerator.Generators.CodeRenderer
    {
        
        /// <summary>
        ///Renders the code as defined in the source script file.
        ///</summary>
        ///<returns></returns>
        public override Kodeo.Reegenerator.Generators.RenderResults Render()
        {
            this.Output.Write("// -------------------------------------------------------\r\n// Automatically gene" +
                    "rated with Kodeo\'s Reegenerator\r\n// Generator: Seasons\r\n// Generation date: ");
            this.Output.Write( System.DateTime.Now.ToString("yyyy-MM-dd hh:mm") );
            this.Output.Write("\r\n// Generated by: ");
            this.Output.Write( System.Security.Principal.WindowsIdentity.GetCurrent().Name );
            this.Output.Write("\r\n// -------------------------------------------------------\r\n\r\n");
 RenderProjectItem(); 
            this.Output.WriteLine();
            return new Kodeo.Reegenerator.Generators.RenderResults(this.Output.ToString());
        }
        
        /// <summary>
        ///Renders the code as defined in the source script file.
        ///</summary>
        ///<param name="item"></param>
        public virtual void RenderItem(string item)
        {
            this.Output.Write("    // ");
            this.Output.Write( item );
            this.Output.WriteLine();
        }
    }
}