using System;
using System.Threading;
using OrganizerCore.Entries;

namespace OrganizerCore
{
    public class Engine
    {
        // get this as constructor parameters
        private IUIDevive controller;
        private IOrganizer organizer;
        private IMenu myMenu;
        private Command currentCommand;
        private IComunicator comunicator;

        public Engine(IUIDevive aController, IOrganizer aOrganizer, IMenu aMyMenu, IComunicator aComunicator)
        {
            this.Controller = aController;
            this.Organizer = aOrganizer;
            this.MyMenu = aMyMenu;
            this.Comunicator = aComunicator;
            this.currentCommand = Command.None;

            this.controller.RaiseButtonOnePressedEvent += this.HandleButtonOnePressedEvent;
            this.controller.RaiseButtonTwoPressedEvent += this.HandleButtonTwoPressedEvent;
            this.controller.RaiseButtonThreePressedEvent += this.HandleButtonThreePressedEvent;
            this.controller.RaiseButtonFourPressedEvent += this.HandleButtonFourPressedEvent;
            this.controller.RaiseButtonLeftPressedEvent += this.HandleButtonLeftPressedEvent;
            this.controller.RaiseButtonRightPressedEvent += this.HandleButtonRightPressedEvent;
            this.controller.RaiseButtonEscPressedEvnet += this.HandleButtonEscPressedEvnet;
            this.controller.RaiseButtonDeletePressedEvnet += this.HandleButtonDeletePressedEvnet;

           // TextFilesIO.ReadEntries(@"../../entries.txt", this.organizer);
        }

        public IMenu MyMenu
        {
            get
            {
                return this.myMenu;
            }

            protected set
            {
                this.myMenu = value;
            }
        }

        public IOrganizer Organizer
        {
            get
            {
                return this.organizer;
            }

            protected set
            {
                this.organizer = value;
            }
        }

        public IUIDevive Controller
        {
            get
            {
                return this.controller;
            }

            protected set
            {
                this.controller = value;
            }
        }

        public IComunicator Comunicator
        {
            get
            {
                return this.comunicator;
            }

            protected set
            {
                this.comunicator = value;
            }
        }

        public void Run()
        {
            this.comunicator.ClearScreen();
            this.MyMenu.DisplayMainMenu();
            while (true)
            {
                if (this.currentCommand != Command.None)
                {
                    this.comunicator.ClearScreen();
                    this.MyMenu.DisplayMainMenu();
                }

                this.currentCommand = Command.None;
                this.controller.GetCommand();

                switch (this.currentCommand)
                {
                    case Command.D1:
                        // View

                        this.comunicator.ClearScreen();
                        this.MyMenu.DisplayView();
                        this.organizer.Restart();

                        while (true)
                        {
                            Entry currentEntry;
                            this.controller.GetCommand();

                            if (this.currentCommand != Command.None)
                            {
                                this.comunicator.ClearScreen();
                                this.MyMenu.DisplayView();

                                if (this.currentCommand == Command.LeftArow)
                                {
                                    this.organizer.GetPrevious();
                                }
                                else if (this.currentCommand == Command.RightArrow)
                                {
                                    this.organizer.GetNext();
                                }
                                else if (this.currentCommand == Command.Delete)
                                {
                                    // delete
                                    if (this.organizer.GetCurrent() == null)
                                    {
                                        this.comunicator.DisplayMessage(new string[] { "No entry" });
                                        this.currentCommand = Command.None;
                                        continue;
                                    }

                                    currentEntry = this.organizer.GetCurrent();

                                    this.organizer.Remove(currentEntry);
                                    this.comunicator.DisplayMessage(new string[] { "->An entry has been deleted!, Moving to the the next entry!" });
                                }
                                else if (this.currentCommand == Command.Esc)
                                {
                                    break;
                                }

                                if (this.organizer.GetCurrent() == null)
                                {
                                    this.comunicator.DisplayMessage(new string[] { "No More Entries" });
                                    this.currentCommand = Command.None;
                                    continue;
                                }

                                currentEntry = this.organizer.GetCurrent();

                                // Display current Info
                                this.comunicator.DisplayMessage(currentEntry.GetInformation());

                                this.currentCommand = Command.None;
                                Thread.Sleep(25);
                            }
                        }

                        break;
                    case Command.D2:    // Adding

                        this.comunicator.ClearScreen();
                        this.MyMenu.DisplayAdd();
                        this.MyMenu.DisplayAddOptions();

                        while (true)
                        {
                            this.currentCommand = Command.None;
                            this.controller.GetCommand();

                            if (this.currentCommand != Command.None)
                            {
                                if (this.currentCommand == Command.D1)
                                {
                                    // Anniversary
                                    this.comunicator.ClearScreen();
                                    this.comunicator.DisplayMessage(new string[] { "Enter Anniversary Info" });
                                    this.comunicator.DisplayMessage(new string[] { "Entry Subject: " });

                                    string subject = this.comunicator.ReadStringData();

                                    this.comunicator.DisplayMessage(new string[] { "Comments: " });
                                    string comment = this.comunicator.ReadStringData();

                                    DateTime date = this.comunicator.ParseDate();

                                    Anniversary newAnniversary = new Anniversary(subject, comment, date);

                                    this.organizer.Add(newAnniversary as Entry);

                                    this.comunicator.DisplayMessage(new string[] { "Anniversary Added Successfully! - Press Esc to Continue" });
                                }
                                else if (this.currentCommand == Command.D2)
                                {
                                    // Meeting
                                    this.comunicator.ClearScreen();
                                    this.comunicator.DisplayMessage(new string[] { "Enter Meeting Info" });
                                    this.comunicator.DisplayMessage(new string[] { "Entry Subject: " });
                                    string subject = this.comunicator.ReadStringData();
                                    this.comunicator.DisplayMessage(new string[] { "Comments: " });
                                    string comment = this.comunicator.ReadStringData();

                                    try
                                    {
                                        DateTime date = this.comunicator.ParseDate();
                                        if (date < DateTime.Now)
                                        {
                                            throw new OutOfRange(DateTime.Now, "Date of Meeting cannot be old - Press Esc to Continue");
                                        }
                                        else
                                        {
                                            Meeting newMeeting = new Meeting(subject, comment, date);

                                            this.organizer.Add(newMeeting as Entry);
                                            this.comunicator.DisplayMessage(new string[] { "Meeting Added Successfully! - Press Esc to Continue" });
                                        }
                                    }
                                    catch (OutOfRange ex)
                                    {
                                        this.comunicator.DisplayMessage(new string[] { ex.Message });
                                    }
                                }
                                else if (this.currentCommand == Command.D3)
                                {
                                    // Memo     
                                    this.comunicator.ClearScreen();
                                    this.comunicator.DisplayMessage(new string[] { "Enter Memo Info" });
                                    this.comunicator.DisplayMessage(new string[] { "Entry Subject: " });
                                    string subject = this.comunicator.ReadStringData();
                                    this.comunicator.DisplayMessage(new string[] { "Comment: " });
                                    string comment = this.comunicator.ReadStringData();

                                    Memo newMemo = new Memo(subject, comment);

                                    this.organizer.Add(newMemo as Entry);
                                    this.comunicator.DisplayMessage(new string[] { "Memo Added Successfully! - Press Esc to Continue" });
                                }

                                if (this.currentCommand == Command.D4)
                                {
                                    // ToDo     
                                    this.comunicator.ClearScreen();
                                    this.comunicator.DisplayMessage(new string[] { "Enter ToDo Info" });
                                    this.comunicator.DisplayMessage(new string[] { "Entry Subject: " });
                                    string subject = this.comunicator.ReadStringData();
                                    this.comunicator.DisplayMessage(new string[] { "Comment: " });
                                    string comment = this.comunicator.ReadStringData();

                                    try
                                    {
                                        DateTime date = this.comunicator.ParseDate();
                                        if (date < DateTime.Now)
                                        {
                                            throw new OutOfRange(DateTime.Now, "Date of ToDo cannot be old - Press Esc to Continue");
                                        }
                                        else
                                        {
                                            ToDo newToDo = new ToDo(subject, comment, date);

                                            this.organizer.Add(newToDo as Entry);
                                            this.comunicator.DisplayMessage(new string[] { "ToDo Added Successfully! - Press Esc to Continue" });
                                        }
                                    }
                                    catch (OutOfRange ex)
                                    {
                                        this.comunicator.DisplayMessage(new string[] { ex.Message });
                                    }
                                }
                                else if (this.currentCommand == Command.Esc)
                                {
                                    break;
                                }
                            }

                            Thread.Sleep(100);
                        }

                        break;
                    case Command.D3: // Alert Mode
                        this.comunicator.ClearScreen();
                        int coutner = 101;
                        while (true)
                        {
                            // Alert Mode
                            this.controller.GetCommand();
                            if (this.currentCommand == Command.Esc)
                            {
                                break;
                            }

                            if (coutner >= 100)
                            {
                                this.controller.GetCommand();
                                this.comunicator.ClearScreen();
                                this.comunicator.DisplayMessage(new string[] { "Alert Mode Entered - press Esc to go to previous menu" });
                                this.organizer.Restart();
                                while (this.organizer.GetCurrent() != null)
                                {
                                    Entry newEntry = this.organizer.GetCurrent();
                                    if (newEntry.IsHot() == true && newEntry.IsObsolete() == false)
                                    {
                                        this.comunicator.DisplayMessage(new string[] { "\nEvent gone hot!" });
                                        this.comunicator.DisplayMessage(newEntry.GetInformation());
                                    }

                                    this.Organizer.GetNext();
                                }

                                coutner = 0;
                            }

                            Thread.Sleep(150);
                            coutner++;
                        }

                        break;

                    case Command.Esc:
                        TextFilesIO.PrintAll(@"../../entries.txt", this.organizer);
                        return;
                }

                // this.currentCommand = Command.None;
                Thread.Sleep(50);
            }
        }

        public void HandleButtonOnePressedEvent(object sender, AnyButtonPressedEventArgs e)
        {
            this.currentCommand = Command.D1;
        }

        public void HandleButtonTwoPressedEvent(object sender, AnyButtonPressedEventArgs e)
        {
            this.currentCommand = Command.D2;
        }

        public void HandleButtonThreePressedEvent(object sender, AnyButtonPressedEventArgs e)
        {
            this.currentCommand = Command.D3;
        }

        public void HandleButtonFourPressedEvent(object sender, AnyButtonPressedEventArgs e)
        {
            this.currentCommand = Command.D4;
        }

        public void HandleButtonLeftPressedEvent(object sender, AnyButtonPressedEventArgs e)
        {
            this.currentCommand = Command.LeftArow;
        }

        public void HandleButtonRightPressedEvent(object sender, AnyButtonPressedEventArgs e)
        {
            this.currentCommand = Command.RightArrow;
        }

        public void HandleButtonEscPressedEvnet(object sender, AnyButtonPressedEventArgs e)
        {
            this.currentCommand = Command.Esc;
        }

        public void HandleButtonDeletePressedEvnet(object sender, AnyButtonPressedEventArgs e)
        {
            this.currentCommand = Command.Delete;
        }
    }
}
