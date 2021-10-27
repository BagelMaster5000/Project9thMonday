->pre_game
===pre_game===
#wwise PreGame_1_Start
[Loading P9M AI...] #4.5
Welcome, user. Thank you for taking part in the beta test of Project 9th Monday. #5.7
This beta test will be having you test an AI-generated horror story based on classic horror movie tropes. #7
As this is a beta test, please be aware that there may be some bugs with the program. #5.25
Most notably, several previous users have reported unintentional crossovers #5
...with our AI-generated children’s show project, designed to create highly marketable edutainment characters. #6.6
Now for the instructions. #2.4
Project 9th Monday does not yet have working graphics. However, all auditory aspects of the project are fully functional. #8
Therefore, all your actions and decisions in the game will be controlled by your voice. #5.5
Depending on what you say or what you don’t say, the story should play out in different ways, with multiple story branches and endings. #7.5
Don’t forget that silence can also be an option. #3
Now, in order to start the game, we ask that you calibrate the voice recognition system. #5.5
->calibration

===calibration===
#wwise PreGame_2_Calibration
Please say the phrase “I want to play a game.” #10
+    [...]
->calibration
+    [I want to play a game]
->begin_game
+    [anything]
->calibration

===begin_game===
#wwise PreGame_3_BeginGame
Very good. Your voice recognition system is now properly calibrated. #4.5
Please enjoy the story "Jewels n' Posts" #8
->outside_the_house



===outside_the_house===
#wwise Outside_1_Start
... #2.8
Jordan: Alright, gang. We’re finally here! Hope the walk wasn’t too much for you all. I doubt any of you do as much training as I get on the football team. #8.6
Paul: Eh, football’s okay, but getting good footage for my channel is where it’s really at. All the fame with none of the head trauma! #8
#6
Hazel: Olá, everyone! Do you see the dog? #10
+    [...]
->wheres_the_dog
+    [I do/yes/yep/yeah/I see it/I can see it/I see the]
->any_questions

===wheres_the_dog===
#wwise Outside_2_WheresTheDog 
Hazel: Where is the dog? Do you see the big, black dog? #4.8
->any_questions

===any_questions===
#wwise Outside_3_AnyQuestions 
Jordan: Yeah, Hazel. We see it. It’s a pretty dog, but we’ve got work to do. I want to just get in, get those jewels, and get out. #11.5
Paul: Can we at least stay long enough to get some good footage? I know you want that GameStation 7, and I do too, but looking up stuff about the Glensdale Gorefiend online only gets me so much material. #10.20
Jordan: Sure, sure. Now let's get inside. #3.8
Jordan: Gotta wonder why they put police tape on a house no one's gonna visit. #2.7
Paul: Well, except for us. #3.5
Jordan: Before we go inside, does anyone have any questions, newbie? I know you’ve been pretty quiet so far. #12
->questions

===questions===
+    [...]
#wwise Outside_4_QuestionSilence
Jordan: You there, newbie? Or are you just thinking of a question to ask? #8
->questions
+    [What are we doing/why]
#wwise Outside_5_Question1
Jordan: We heard this place has some old jewels that should be worth a lot of money. Hopefully it’ll be enough for us to get the new GameStation 7. #7.5
Jordan: And, y’know, Paul also came along so he could get footage for a video he’s making. #3.7
Jordan: You have any other questions, newbie? #8
->questions
+    [What day is it/what day/when/halloween/time]
#wwise Outside_6_Question2
Jordan: It’s Halloween night! Fitting time to go digging around in an abandoned house, huh? #5.2
Jordan: You have any other questions, newbie? #8
->questions
+    [Who are you people/who are]
#wwise Outside_7_Question3
Jordan: I’m Jordan, the main quarterback at Glensdale High. #3.9
Jordan: Paul over there is part of the AV Club and apparently has some paranormal blog. #3.9
Jordan: Hazel over there… I honestly don’t really know her deal. She came to us with the whole idea for visiting this place. She’s also kind of… odd. #9.5
Jordan: Sometimes, I feel like she’s talking to someone we can’t see, and she sometimes <i>really</i> insists on us acknowledging what she says. Remember that whole bit with the dog back there? #10.9
Jordan: You have any other questions, newbie? #8
->questions
+    [Whose idea was this/idea]
#wwise Outside_8_Question4
Jordan: Funnily enough, it was Hazel’s idea. She asked us if we wanted to go on an adventure on Halloween night, #5
Jordan: and when she mentioned the ghostly jewels this place had me and Paul came up with the idea to sell ‘em somewhere so we could buy a GameStation 7. #7.7
Jordan: You have any other questions, newbie? #8
->questions
+    [Where are we/where/location]
#wwise Outside_9_Question5
Jordan: We're right outside the haunted house. It's right on the outskirts of Glensdale. #4.2
Jordan: You have any other questions, newbie? #8
->questions
#wwise Outside_10_QuestionDone
+    [No questions here/none/I'm not/nope/nah/no/I'm good]
Jordan: Alright, lets get to it! #2.6
... #12.5
->main_hall

===main_hall===
#wwise MainHall_1_Start
... #3.5
Hazel: We’re in the main hall now! Look at how big it is! #5.2
Paul: Yeah, it’s pretty nice for an abandoned house. The Glensdale Gorefiend has some good taste in interior design. Assuming they’re real and actually live here. It’s kind of spooky. #12.2
Jordan: Alright, gang. This place looks like it’s gonna take a while to search, so I think it’d be best for us to split up so we can cover more ground. I’ll go cover the first floor. #10.5
Jordan: You think you’ll be okay checking upstairs with Hazel, Paul? #3
Paul: Sure, I think she’ll be okay with me. Right, Hazel? #4
Hazel: Wow, this house is muito assustador! (very scary) #4.7
Paul: Yeah, she’ll be fine. #3.5
Jordan: Hey, newbie. Who do you feel like going with? I think I can manage on my own, but I wouldn’t mind having a second pair of eyes help me look for the jewels. #18
->team_up

===team_up===
+    [...]
#wwise MainHall_2_QuestionSilence
Jordan: Come on, the faster you choose the faster we can start looking! Do you want to go with me or with Paul and Hazel? #11
->team_up
+    [Jordan/you]
#wwise MainHall_3_QuestionJordan
Jordan: Alright! Stick with me and no ghost or Gorefiend will be messing with us! #6
->teamed_with_jordan
+    [Paul and Hazel/paul/hazel/them]
#wwise MainHall_4_QuestionPaulHazel
Jordan: Cool, I’ll see you three in a bit. Just don’t get grabbed by any monsters! *laughs* #6.75
->teamed_with_p_and_h
+    [Why are we splitting up/why]
#wwise MainHall_5_Question1
Jordan: This old place is pretty big, and I’m sure you don’t want to stay here any longer than the rest of us do. #5.2
Jordan: If we split up, we should be able to find the jewels twice as fast. I’m sure we can hear each other if one of us starts shouting because they found the jewels or something worse. #9.3
Jordan: So, who do you want to go with? #8
->team_up
+    [Doesn't that seem dangerous/dangerous/reckless/dumb/stupid/idiot/get killed]
#wwise MainHall_6_Question2
Jordan: Nah, we’ll be fine! I could easily handle any weirdo on my own with my quarterback tackle, #7.7
Jordan: ...and I’m having Paul and Hazel go together so they can outnumber the Glensdale Gorefiend if they <i>are</i> hanging out here. #7.1
Jordan: So, who do you want to go with? #8
->team_up



===teamed_with_jordan
#wwise JordanPath_1_Start
... #3.7
Jordan: I know you’re new to the area, but I bet you’ve heard about how I helped help bring the Glensdale Gorgons to a narrow 21-20 win against the Barkland Bulls. #8.8
Jordan: I tell you, when the big-time football people come calling, that’s the story they’ll be hearing! #7.1
Jordan: Right, so the jewels. #1.65
Jordan: Obviously, some of it’s going towards the GameStation, but some of that’s definitely going towards getting to a good college. #5.9
Jordan: Some folks go to a good college for a good degree, but I’m looking at one with a sick football team. That’s how you get into the big lea- #6.9
(Demonic Laugh) #2
Jordan: What the hell was that!? (beat) I-I think it came from the kitchen over there. I bet the Glensdale Gorefiend is in there! Newbie, got any idea what to do? #16
->in_or_not1

===in_or_not1===
+    [...]
#wwise JordanPath_2_Question1Silence
Jordan: I could really use an answer now! Should I check out that noise? #9.5
->in_or_not1
+    [Don't go inside/don't go/do not go/idiot]
->in_or_not2
+    [Go in there/go/inside]
->tackling_time
+    [anything]
->in_or_not2

===tackling_time===
#wwise JordanPath_3_TacklingTime
Jordan: You got it. I’ll show that weirdo my all-star tackling skills! #4
->jordan_converge

===in_or_not2===
#wwise JordanPath_4_Ignoring1
Jordan: (beat) Sorry, I was trying to hear anything going on in there. Did I hear you say “go in there?” #11
+    [Yes/yeah/yep/I sure did/correct]
->tackling_time
+    [anything]
#wwise JordanPath_5_Ignoring2
Jordan: Yeah, I definitely heard a “go in there.” You wait here, newbie. I’ll handle this. #4.7
->jordan_converge

===jordan_converge===
#wwise JordanPath_6_Convergence
... #18.8
Jordan: Okay, so good news and somewhat-in-the-middle news. There’s no one in the kitchen. That’s when I decided to make a bunch of noise in here so if the Gorefiend IS in the house, they’d be scared off. #11.8
Jordan: Hopefully that’ll be the last bit of weirdness we’ll have to deal with. #6.5
->alone1



===teamed_with_p_and_h
#wwise PaulHazelPath_1_Start
... #8.8
Hazel: We’re on the second floor of the spooky house! I bet we could see the entire town from here! #7
Paul: Yeah, we probably could, Hazel. So, whats-your-face, you got any cool plans for the money we’ll get from those jewels? #7.6
Paul: Other than the GameStation, mine are pretty simple: better video equipment. I’ve been looking at some stuff to help make my vids really pop. #8.6
Paul: I know some folks say that becoming a popular video maker requires some luck, but I bet some great editing and high-quality footage can help with that! #8.8
Paul: Funny story, but I got the idea for doing recordings of haunted places from this game I once saw. #5.9
Paul: In it, this Girl who video tapes haunted locations goes to this abandoned mansion that was owned by some cult that mysteriously vanished, and she- #7.3
(Demonic Scream) #2.8
Hazel: Meu Deus! (Oh my God!) That was loud! #16.5
+    [...]
->pauls_phone
+    [anything]
->pauls_phone

===pauls_phone===
#wwise PaulHazelPath_2_PaulsPhone
Paul: Riiiiiight, I probably should have mentioned that earlier. That was a ringtone I got for when my mom calls or texts me. #11.1
Paul: I’m a bit hard of hearing so I chose a noise that I’d be sure to hear. Normally, it’s something different, but I figured I’d make it something scary since it’s Halloween. She’s just asking about the party I claimed we were going to. #12.6
(Plates Crashing) #3.3
Paul: That… was not my phone. That sounded like it came from the kitchen! We have to hide! Where should wo go? #14
->where_to_run

===where_to_run===
+    [...]
#wwise PaulHazelPath_3_QuestionSilence
Paul: C’mon, throw out some ideas! Where should we hide? #10
->where_to_run
+    [Basement/cellar]
#wwise PaulHazelPath_4_QuestionBasement
Paul: I was thinking that too! It’ll be extra-dark, there’ll likely be lots of places for us to hide in there, and we might be able to find some tools left down there. Now, back down the stairs! #16
->basement
+    [Outside/out/front door/away from the house/run/leave]
#wwise PaulHazelPath_5_QuestionOutside
Paul: We can’t run! The jewels are still in the house, and whatever’s in here could easily chase us down! We need to think of somewhere safe and quiet... #14
->where_to_run
+    [Attic]
#wwise PaulHazelPath_6_QuestionAttic
Paul: Maybe, but if we had to flee, the only other way out is through a window. I don’t think I could take crashing through a third-story window and falling like 30 feet. Let's think lower... #17.5
->where_to_run
+    [Kitchen/the noise]
#wwise PaulHazelPath_7_QuestionKitchen
Paul: Great idea! We’re going right to where the Gorefiend is, or whoever else lives here! C’mon, be serious here! #15
->where_to_run

===basement===
#wwise PaulHazelPath_8_Basement
... #7
Paul: Okay, I don’t think anyone’s going to find us down here. (beat) Wait, where did Hazel go? Oh no… #10.3
Paul: Wha- the lights turned on! #2.7
Hazel: Well done! You found the light switch! #2.9
Paul: Hazel! We thought you got lost, or worse! Where were you? Ah, that doesn’t matter now. Anyway, looks like there are some old boxes down here. Help me look through them, you guys. #13.6
(Rummaging Through Boxes) #3.9
Paul: Hang on. This house… why does it have power if it’s abandoned? Unless… it <i>isn’t</i> abandoned. #14.9
#wwise Lost_1_Start
... #15
->alone1




===alone1===
+    [...]
... #15
->alone1
+    [Hello/paul/jordan/hazel/where/help/lost]
#wwise Lost_2_Wandering
... #15
->alone2

===alone2===
+    [...]
... #15
->alone2
+    [Hello/paul/jordan/hazel/where/help/lost]
#wwise Lost_3_OpenDoor
... #15
->alone3

===alone3===
+    [...]
... #15
->alone3
+    [Hello/paul/jordan/hazel/where/help/lost]
->theres_hazel

===theres_hazel===
#wwise TheresHazel_1_Start
... #4.9
Hazel: Olá, player! It looks like Jordan and Paul have gone missing! Where could they have gone? #8.9
Hazel: Did you hear that? It sounded like it came from upstairs! We should go investigate! Vamos lá! (Let’s go!) #13.3
Hazel: We’ve reached the top of the stairs, but we still don’t know where our friends are! Where could our friends have been taken? #7.9
Hazel: I’ve got an idea! They must be in the attic! Let’s help them! #14.3
->the_climatic_encounter

===the_climatic_encounter===
#wwise Climax_1_Start
... #2.5
Hazel: We’re in the Glensdale Gorefiend’s lair! Can you find your friends? #4.9
(Muffled Screaming) #1.45
Hazel: There they are! They’ve been waiting for you to help them, but you won’t be able to! #6.7
Hazel: It gets boring not killing people! That’s why it’s so great to have people come to my lair! #7.5
Hazel: That way, I don’t have to worry about most people trying to investigate because of all the scary rumors! Now, do you know what’s going to happen to you and your friends? #11.8
Hazel: That’s right! You’re all going to bleed out on the attic floor! #0.66
VAR hazelLoopsRemaining = 1
->do_you_want_death

===do_you_want_death===
#wwise Climax_2_DoYouWantToDie
Hazel: Now, player. Do you want to die? #8 
+    {hazelLoopsRemaining > 0} [...]
~ hazelLoopsRemaining--
   ->do_you_want_death
+    {hazelLoopsRemaining <= 0} [...]
~ hazelLoopsRemaining--
   ->lifesaving_update
+    [Yes/yep/yeah/don't mind if I do/please/of course/for sure/definitely]
#wwise Climax_3_QuestionYes
Hazel: You’re funny! I wonder if you’d say the same thing after you’re disemboweled! #5.6
->bad_end
+    [No/nope/nah/not interested]
#wwise Climax_2_QuestionNo
Hazel: That’s too bad! #2.2
->bad_end



===bad_end===
#wwise BadEnding_1_Start
Hazel: Now, click on who you want to die first! #6.5
:( #3.65
[Loading P9M AI...] #3.45
Thank you for assisting us with the testing of our AI-generated story program. While you were unsuccessful in surviving the story, we are always grateful to our testers for helping us troubleshoot and giving us feedback. Please take your complimentary baggie of candy corn as you leave the testing site. #22.85
    -> END
    
    
    
===lifesaving_update===
#wwise GoodEnding_1_Start
[Loading P9M AI...] #2.6
Attention tester. We have a new patch available for Project 9th Monday that fixes a few minor bugs. #6.35
Most notably, this patch will prevent the unintentional crossovers that testers have reported with our AI-generated children’s show generator. Updating now. #11.6
Jordan: Bwah! Holy crap! How’d you manage to get the Glensdale Gorefiend to vanish like that? #6.05
Paul: I guess those rumors about them being a demon from Hell were true, and you sent them right back there somehow. But seriously, you totally saved our lives! #10.75
Jordan: Whew, the last time my heart was pounding this much was after that two-hour training session for last season’s final game. Let’s get goin’ home. #8.25
Paul: Hang on. We’re in the Gorefiend’s inner sanctum. I want to get a bit of footage of this place and the furniture before we go. #7.7
Jordan: Well, I doubt anything else is going to be trying to kill us here. Okay, but not too long. #8
Paul: Oh man, guys. Three guesses what I found, and I’ll tell you now it’s not anything scary or gory. #6.95
+ [...]
->jewels_are_real
+ [jewels]
#wwise GoodEnding_2_QuestionCorrect
Paul: You got it, it's the jewels! #3
->jewels_are_real
+ [anything]
#wwise GoodEnding_3_QuestionWrong
Paul: Nope! You want to take a guess, Jordan? #3.9
->jewels_are_real

===jewels_are_real===
#wwise GoodEnding_4_JewelsReal
Jordan: Wait, are you saying those jewels… are real? I was starting to think it was some rumor the Gorefiend made up! #7.9
Paul: Well, it’s time to stop doubting and time to start bringing these riches home! #4.3
(Laughter) #4.1
->good_ending

===good_ending===
#wwise GoodEnding_5_AICongratulations
[Loading P9M AI...] #4.2
Thank you for helping us test out the latest build of Project 9th Monday. In addition, congratulations for reaching the good ending of the story. #8.85
While the story had to make some adjustments to compensate for the villain’s sudden disappearance, it would seem that it managed to properly remain on track. #7.65
We are always grateful to our testers for helping us troubleshoot and give us feedback. #5
Please take your assorted package of king-sized candies as you leave the testing site. #14
-> END
