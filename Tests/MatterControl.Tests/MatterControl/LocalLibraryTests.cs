﻿using MatterHackers.Agg;
using MatterHackers.Agg.Image;
using MatterHackers.Agg.UI;
using NUnit.Framework;
using System;
using System.Linq;
using System.Threading.Tasks;
using MatterHackers.GuiAutomation;
using MatterHackers.Agg.PlatformAbstract;
using System.IO;
using MatterHackers.MatterControl.CreatorPlugins;
using MatterHackers.Agg.UI.Tests;
using MatterHackers.MatterControl.PrintQueue;
using MatterHackers.MatterControl.DataStorage;
using System.Diagnostics;

namespace MatterHackers.MatterControl.UI
{
	[TestFixture, Category("MatterControl.UI"), RunInApplicationDomain]
	public class AddSingleItemToLocalLibrary
	{
		[Test, RequiresSTA, RunInApplicationDomain]
		public void LocalLibraryAddButtonAddSingleItemToLibrary()
		{
			// Run a copy of MatterControl
			Action<AutomationTesterHarness> testToRun = (AutomationTesterHarness resultsHarness) =>
			{
				AutomationRunner testRunner = new AutomationRunner(MatterControlUtilities.DefaultTestImages);
				{

					string itemName = "Row Item " + "Fennec Fox";


					//Navigate to Local Library 
					testRunner.ClickByName("Library Tab");
					MatterControlUtilities.NavigateToFolder(testRunner, "Local Library Row Item Collection");

					//Make sure that Item does not exist before the test begins
					bool rowItemExists = testRunner.WaitForName(itemName, 1);
					resultsHarness.AddTestResult(rowItemExists == false);

					//Click Local Library Add Button
					testRunner.ClickByName("Library Add Button");

					//Get Library Item to Add
					string rowItemPath = MatterControlUtilities.PathToQueueItemsFolder("Fennec_Fox.stl");
					testRunner.Wait(2);
					testRunner.Type(rowItemPath);
					testRunner.Wait(1);
					testRunner.Type("{Enter}");

					bool rowItemWasAdded = testRunner.WaitForName(itemName, 2);
					resultsHarness.AddTestResult(rowItemWasAdded == true);


					MatterControlUtilities.CloseMatterControl(testRunner);
				}
			};

			AutomationTesterHarness testHarness = MatterControlUtilities.RunTest(testToRun);

			Assert.IsTrue(testHarness.AllTestsPassed);
			Assert.IsTrue(testHarness.TestCount == 2); // make sure we ran all our tests
		}
	}

	[TestFixture, Category("MatterControl.UI"), RunInApplicationDomain]
	public class AddMultipleItemsToLocalLibrary
	{
		[Test, RequiresSTA, RunInApplicationDomain]
		public void LocalLibraryAddButtonAddsMultipleItemsToLibrary()
		{
			// Run a copy of MatterControl
			Action<AutomationTesterHarness> testToRun = (AutomationTesterHarness resultsHarness) =>
			{
				AutomationRunner testRunner = new AutomationRunner(MatterControlUtilities.DefaultTestImages);
				{


					//Names of Items to be added
					string firstItemName = "Row Item " + "Fennec Fox";
					string secondItemName = "Row Item " + "Batman";

					//Navigate to Local Library 
					testRunner.ClickByName("Library Tab");
					MatterControlUtilities.NavigateToFolder(testRunner, "Local Library Row Item Collection");

					//Make sure both Items do not exist before the test begins
					bool firstItemExists= testRunner.WaitForName(firstItemName, 1);
					bool secondItemExists = testRunner.WaitForName(secondItemName, 1);
					resultsHarness.AddTestResult(firstItemExists == false);
					resultsHarness.AddTestResult(secondItemExists == false);

					//Click Local Library Add Button
					testRunner.ClickByName("Library Add Button");

					//Get Library Item to Add
					string firstRowItemPath = MatterControlUtilities.PathToQueueItemsFolder("Fennec_Fox.stl");
					string secondRowItemPath = MatterControlUtilities.PathToQueueItemsFolder("Batman.stl");

					string textForBothRowItems = String.Format("\"{0}\" \"{1}\"", firstRowItemPath, secondRowItemPath);
					testRunner.Wait(2);
					testRunner.Type(textForBothRowItems);
					testRunner.Wait(1);
					testRunner.Type("{Enter}");


					bool firstRowItemWasAdded = testRunner.WaitForName(firstItemName, 2);
					bool secondRowItemWasAdded = testRunner.WaitForName(secondItemName, 2);
					resultsHarness.AddTestResult(firstRowItemWasAdded == true);
					resultsHarness.AddTestResult(secondRowItemWasAdded == true);


					MatterControlUtilities.CloseMatterControl(testRunner);
				}
			};

			AutomationTesterHarness testHarness = MatterControlUtilities.RunTest(testToRun);

			Assert.IsTrue(testHarness.AllTestsPassed);
			Assert.IsTrue(testHarness.TestCount == 4); // make sure we ran all our tests
		}
	}

	[TestFixture, Category("MatterControl.UI"), RunInApplicationDomain]
	public class AddAMFItemToLocalLibrary
	{
		[Test, RequiresSTA, RunInApplicationDomain]
		public void LocalLibraryAddButtonAddAMFToLibrary()
		{
			// Run a copy of MatterControl
			Action<AutomationTesterHarness> testToRun = (AutomationTesterHarness resultsHarness) =>
			{
				AutomationRunner testRunner = new AutomationRunner(MatterControlUtilities.DefaultTestImages);
				{

					string itemName = "Row Item " + "Rook";

					//Navigate to Local Library 
					testRunner.ClickByName("Library Tab");
					MatterControlUtilities.NavigateToFolder(testRunner, "Local Library Row Item Collection");

					//Make sure that Item does not exist before the test begins
					bool rowItemExists = testRunner.WaitForName(itemName, 1);
					resultsHarness.AddTestResult(rowItemExists == false);

					//Click Local Library Add Button
					testRunner.ClickByName("Library Add Button");

					//Get Library Item to Add
					string rowItemPath = MatterControlUtilities.PathToQueueItemsFolder("Rook.amf");
					testRunner.Wait(2);
					testRunner.Type(rowItemPath);
					testRunner.Wait(1);
					testRunner.Type("{Enter}");

					bool rowItemWasAdded = testRunner.WaitForName(itemName, 2);
					resultsHarness.AddTestResult(rowItemWasAdded == true);


					MatterControlUtilities.CloseMatterControl(testRunner);
				}
			};

			AutomationTesterHarness testHarness = MatterControlUtilities.RunTest(testToRun);

			Assert.IsTrue(testHarness.AllTestsPassed);
			Assert.IsTrue(testHarness.TestCount == 2); // make sure we ran all our tests
		}
	}

	[TestFixture, Category("MatterControl.UI"), RunInApplicationDomain]
	public class AddZipFileToLocalLibrary
	{
		[Test, RequiresSTA, RunInApplicationDomain]
		public void LocalLibraryAddButtonAddZipToLibrary()
		{
			// Run a copy of MatterControl
			Action<AutomationTesterHarness> testToRun = (AutomationTesterHarness resultsHarness) =>
			{
				AutomationRunner testRunner = new AutomationRunner(MatterControlUtilities.DefaultTestImages);
				{

					//Items in Batman.zip
					string firstItemName = "Row Item " + "Batman";
					string secondItemName = "Row Item " + "2013-01-25 Mouthpiece v2";

					//Navigate to Local Library 
					testRunner.ClickByName("Library Tab");
					MatterControlUtilities.NavigateToFolder(testRunner, "Local Library Row Item Collection");

					//Make sure that Item does not exist before the test begins
					bool firstItemInZipExists = testRunner.WaitForName(firstItemName, 1);
					bool secondItemInZipExists = testRunner.WaitForName(secondItemName, 1);
					resultsHarness.AddTestResult(firstItemInZipExists == false);
					resultsHarness.AddTestResult(firstItemInZipExists == false);

					//Click Local Library Add Button
					testRunner.ClickByName("Library Add Button");

					//Get Library Item to Add
					string rowItemPath = MatterControlUtilities.PathToQueueItemsFolder("Batman.zip");
					testRunner.Wait(2);
					testRunner.Type(rowItemPath);
					testRunner.Wait(1);
					testRunner.Type("{Enter}");

					bool firstItemInZipWasAdded = testRunner.WaitForName(firstItemName, 2);
					bool secondItemInZipWasAdded = testRunner.WaitForName(secondItemName, 2);
					resultsHarness.AddTestResult(firstItemInZipWasAdded == true);
					resultsHarness.AddTestResult(secondItemInZipWasAdded == true);


					MatterControlUtilities.CloseMatterControl(testRunner);
				}
			};

			AutomationTesterHarness testHarness = MatterControlUtilities.RunTest(testToRun);

			Assert.IsTrue(testHarness.AllTestsPassed);
			Assert.IsTrue(testHarness.TestCount == 4); // make sure we ran all our tests
		}
	}

	[TestFixture, Category("MatterControl.UI"), RunInApplicationDomain]
	public class RenameButtonRenamesLibraryRowItem
	{
		[Test, RequiresSTA, RunInApplicationDomain]
		public void RenameButtonRenameLocalLibraryItem()
		{
			// Run a copy of MatterControl
			Action<AutomationTesterHarness> testToRun = (AutomationTesterHarness resultsHarness) =>
			{
				AutomationRunner testRunner = new AutomationRunner(MatterControlUtilities.DefaultTestImages);
				{

					//Navigate To Local Library 
					testRunner.ClickByName("Library Tab");
					MatterControlUtilities.NavigateToFolder(testRunner, "Local Library Row Item Collection");

					testRunner.Wait(1);

					string rowItemToRename = "Row Item " + "Calibration - Box";
					testRunner.ClickByName("Library Edit Button");
					testRunner.Wait(1);
					testRunner.ClickByName(rowItemToRename);
					testRunner.ClickByName("Rename From Library Button");

					testRunner.Wait(2);

					testRunner.Type("Library Item Renamed");

					testRunner.ClickByName("Rename Button");

					string renamedRowItem = "Row Item " + "Library Item Renamed";
					bool libraryItemWasRenamed = testRunner.WaitForName(renamedRowItem, 2);
					bool libraryItemBeforeRenameExists = testRunner.WaitForName(rowItemToRename, 2);

					resultsHarness.AddTestResult(libraryItemWasRenamed == true);
					resultsHarness.AddTestResult(libraryItemBeforeRenameExists == false);


					MatterControlUtilities.CloseMatterControl(testRunner);
				}
			};

			AutomationTesterHarness testHarness = MatterControlUtilities.RunTest(testToRun);

			Assert.IsTrue(testHarness.AllTestsPassed);
			Assert.IsTrue(testHarness.TestCount == 2); // make sure we ran all our tests
		}
	}


	[TestFixture, Category("MatterControl.UI"), RunInApplicationDomain]
	public class UserCanSuccessfullyCreateLibraryFolder
	{
		[Test, RequiresSTA, RunInApplicationDomain]
		public void RenameButtonRenameLocalLibraryItem()
		{
			// Run a copy of MatterControl
			Action<AutomationTesterHarness> testToRun = (AutomationTesterHarness resultsHarness) =>
			{
				AutomationRunner testRunner = new AutomationRunner(MatterControlUtilities.DefaultTestImages);
				{
					//Navigate to Local Library
					testRunner.ClickByName("Library Tab");
					MatterControlUtilities.NavigateToFolder(testRunner, "Local Library Row Item Collection");

					//Create New Folder
					testRunner.ClickByName("Create Folder From Library Button");
					testRunner.Wait(.5);
					testRunner.Type("New Folder");
					testRunner.Wait(.5);
					testRunner.ClickByName("Create Folder Button");

					//Check for Created Folder
					string newLibraryFolder = "New Folder Row Item Collection";
					bool newFolderWasCreated = testRunner.WaitForName(newLibraryFolder, 1);
					resultsHarness.AddTestResult(newFolderWasCreated == true);

					MatterControlUtilities.CloseMatterControl(testRunner);
				}
			};

			AutomationTesterHarness testHarness = MatterControlUtilities.RunTest(testToRun);

			Assert.IsTrue(testHarness.AllTestsPassed);
			Assert.IsTrue(testHarness.TestCount == 1); // make sure we ran all our tests
		}
	}





}