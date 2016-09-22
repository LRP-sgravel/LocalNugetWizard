using System.Collections.Generic;
using System.IO;
using Microsoft.VisualStudio.TemplateWizard;
using EnvDTE;

namespace LocalNuGetWizard
{
    public class LocalNuGetWizard : IWizard
    {
        // This method is called before opening any item that 
        // has the OpenInEditor attribute.
        public void BeforeOpeningFile(ProjectItem projectItem)
        {
        }

        public void ProjectFinishedGenerating(Project project)
        {
        }

        // This method is only called for item templates,
        // not for project templates.
        public void ProjectItemFinishedGenerating(ProjectItem projectItem)
        {
        }

        // This method is called after the project is created.
        public void RunFinished()
        {
        }

        // Copy our Nuget...
        public void RunStarted(object automationObject, Dictionary<string, string> replacementsDictionary, WizardRunKind runKind, object[] customParams)
        {
            var templatePath = customParams[0] as string;
            var packagePath = Path.GetDirectoryName(templatePath);
            var solutionPath = replacementsDictionary["$solutiondirectory$"];
            FileInfo[] packageFiles = new DirectoryInfo(Path.Combine(packagePath, "LocalPackages")).GetFiles();

            File.Copy(Path.Combine(packagePath, "NuGet.config"), Path.Combine(solutionPath, "NuGet.config"));

            Directory.CreateDirectory(Path.Combine(solutionPath, "LocalPackages"));

            foreach (FileInfo fileName in packageFiles)
            {
                File.Copy(Path.Combine(packagePath, "LocalPackages", fileName.Name),
                          Path.Combine(solutionPath, "LocalPackages", fileName.Name));
            }
        }

        // This method is only called for item templates,
        // not for project templates.
        public bool ShouldAddProjectItem(string filePath)
        {
            return true;
        }        
    }
}
