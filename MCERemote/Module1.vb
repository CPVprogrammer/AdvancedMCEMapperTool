Imports System.Xml

Module Module1
    Public sections() As String = {"global", "LoginScreen", "Home", "VirtualKeyboard", "MyTVChannels", "MyTVRecordings", "MyTVTimers", "MyRadioChannels",
                                   "MyRadioRecordings", "MyRadioTimers", "MyFiles", "MyMusicPlaylist", "MyMusicPlaylistEditor", "MyMusicFiles", "MyMusicLibrary",
                                   "FullscreenVideo", "VideoTimeSeek", "FullscreenInfo", "PlayerControls", "Visualisation", "MusicOSD", "VisualisationSettings",
                                   "VisualisationPresetList", "SlideShow", "ScreenCalibration", "GUICalibration", "VideoOSD", "VideoMenu", "OSDVideoSettings",
                                   "OSDAudioSettings", "VideoBookmarks", "MyVideoLibrary", "MyVideoFiles", "MyVideoPlaylist", "MyPictures", "ContextMenu",
                                   "Scripts", "MusicInformation", "MovieInformation", "PictureInfo", "Teletext", "Favourites", "NumericInput", "FullscreenLiveTV",
                                   "FullscreenRadio", "PVROSDChannels", "PVROSDGuide", "PVROSDDirector", "PVROSDCutter", "MyTVSettings", "FileBrowser",
                                   "ShutdownMenu", "AddonInformation", "AddonSettings", "Addon"
                                  }

    Public actions() As String = {"Left", "Right", "Up", "Down", "Select", "enter", "PageUp", "PageDown", "Highlight", "ParentDir", "PreviousMenu", "back",
                                  "Info", "Pause", "Stop", "SkipNext", "SkipPrevious", "FullScreen", "togglefullscreen", "AspectRatio", "StepForward",
                                  "StepBack", "BigStepForward", "BigStepBack", "SmallStepBack", "ChapterOrBigStepForward", "ChapterOrBigStepBack", "NextScene",
                                  "PreviousScene", "OSD", "osdleft", "osdright", "osdup", "osddown", "osdselect", "osdvalueplus", "osdvalueminus", "PlayDVD",
                                  "ShowVideoMenu", "ShowSubtitles", "NextSubtitle", "subtitleshiftup", "subtitleshiftdown", "subtitlealign", "CodecInfo",
                                  "NextPicture", "PreviousPicture", "ZoomOut", "ZoomIn", "IncreasePAR", "DecreasePAR", "Queue", "Filter", "Playlist",
                                  "ZoomNormal", "ZoomLevel1", "ZoomLevel2", "ZoomLevel3", "ZoomLevel4", "ZoomLevel5", "ZoomLevel6", "ZoomLevel7", "ZoomLevel8",
                                  "ZoomLevel9", "NextCalibration", "ResetCalibration", "AnalogMove", "Rotate", "rotateccw", "Close", "subtitledelay",
                                  "SubtitleDelayMinus", "SubtitleDelayPlus", "audiodelay", "AudioDelayMinus", "AudioDelayPlus", "AudioNextLanguage",
                                  "NextResolution", "Number0", "Number1", "Number2", "Number3", "Number4", "Number5", "Number6", "Number7", "Number8", "Number9",
                                  "FastForward", "Rewind", "Play", "PlayPause", "Delete", "Copy", "Move", "Rename", "HideSubmenu", "Screenshot", "ShutDown()",
                                  "VolumeUp", "VolumeDown", "Mute", "volampup", "volampdown", "audiotoggledigital", "BackSpace", "ScrollUp", "ScrollDown",
                                  "AnalogFastForward", "AnalogRewind", "AnalogSeekForward", "AnalogSeekBack", "MoveItemUp", "MoveItemDown", "ContextMenu",
                                  "Shift", "Symbols", "CursorLeft", "CursorRight", "ShowTime", "visualisationpresetlist", "ShowPreset", "NextPreset",
                                  "PreviousPreset", "LockPreset", "RandomPreset", "IncreaseRating", "DecreaseRating", "ToggleWatched", "NextLetter", "PrevLetter",
                                  "JumpSMS2", "JumpSMS3", "JumpSMS4", "JumpSMS5", "JumpSMS6", "JumpSMS7", "JumpSMS8", "JumpSMS9",
                                  "FilterSMS2", "FilterSMS3", "FilterSMS4", "FilterSMS5", "FilterSMS6", "FilterSMS7", "FilterSMS8", "FilterSMS9",
                                  "verticalshiftup", "verticalshiftdown", "scanitem", "reloadkeymaps", "increasevisrating", "decreasevisrating", "firstpage",
                                  "lastpage", "guiprofile", "red", "green", "yellow", "blue", "toggledebug", "ActivateWindow(MyVideos)",
                                  "ActivateWindow(MyMusic)", "ActivateWindow(MyPictures)", "ActivateWindow(Home)", "createbookmark", "createepisodebookmark",
                                  "NextChannelGroup", "PreviousChannelGroup", "PlayPvr", "PlayPvrTV", "PlayPvrRadio", "Record", "StereoMode", "ToggleStereoMode",
                                  "SwitchPlayer", "UpdateLibrary(video)"
                                 }

    Public numbersString() As String = {"zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine"}

    Public specialKeys() As String = {"NumPad /", "NumPad *", "NumPad -", "NumPad +", "NumPad Enter", "NumPad Del",
                                      "NumPad 0", "NumPad 1", "NumPad 2", "NumPad 3", "NumPad 4", "NumPad 5", "NumPad 6", "NumPad 7",
                                      "NumPad 8", "NumPad 9", "Play/Pause", "Next/Skip", "Previous/Replay",
                                      "Keyboard Power", "Keyboard Mute", "Keyboard VolumeUP", "Keyboard VolumeDown"
                                     }

    Public specialKeysKodi() As String = {"numpaddivide", "numpadtimes", "numpadminus", "numpadplus", "enter", "numpadperiod", "numpadzero",
                                          "numpadone", "numpadtwo", "numpadthree", "numpadfour", "numpadfive", "numpadsix", "numpadseven", "numpadeight",
                                          "numpadnine", "play_pause", "SkipNext", "SkipPrevious",
                                          "power", "volume_mute", "volume_up", "volume_down"
                                         }

    Public appPath As String = Application.StartupPath()
    Public shareCTRL As Boolean
    Public shareALT As Boolean
    Public shareShift As Boolean
    Public shareWindows As Boolean
    Public shareKey As String

    Public xmlKeyboard As String
    Public searchNodeList As XmlNodeList

    Public sectionsList As New ArrayList
    Public sectionsDataGrid As New ArrayList

    Public actionsList As New ArrayList
    Public actionsDataGrid As New ArrayList

    Public contFound As Integer
End Module


