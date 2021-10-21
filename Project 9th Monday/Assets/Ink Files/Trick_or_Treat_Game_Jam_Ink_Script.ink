->pre_game
===pre_game===
AI: Welcome, user. Thank you for taking part in the beta test of Project 9th Monday. This beta test will be having you test an AI-generated horror story based on classic horror movie tropes. As this is a beta test, please be aware that there may be some bugs with the program. Most notably, several previous users have reported unintentional crossovers with our AI-generated children’s show project, designed to create highly marketable edutainment characters. Now for the instructions.
AI: Project 9th Monday does not yet have working graphics. However, all auditory aspects of the project are fully functional. Therefore, all your actions and decisions in the game will be controlled by your voice. Depending on what you say or what you don’t say, the story should play out in different ways, with multiple story branches and endings. Don’t forget that silence can also be an option.
->calibration
===calibration===
AI: Now, in order to start the game, we ask that you calibrate the voice recognition system. Please say the phrase “I want to play a game.”
+    [...]
->calibration
+    [I want to play a game.]
->begin_game
===begin_game===
Very good. Your voice recognition system is now properly calibrated. Please enjoy the story [the title of the game would likely go here]
->outside_the_house
===outside_the_house===
Jordan: Alright, gang. We’re finally here! Hope the walk wasn’t too much for you all. I doubt any of you do as much training as I get on the football team.
Paul: Eh, football’s okay, but getting good footage for my channel is where it’s really at. All the fame with none of the head trauma!
Hazel: Olá, everyone! Do you see the dog?
+    [...]
->wheres_the_dog
+    [I do.]
->any_questions
===wheres_the_dog===
Hazel: Where is the dog? Do you see the big, black dog?
Jordan: Yeah, Hazel. We see it. It’s a pretty dog, but we’ve got work to do. I want to just get in, get those jewels, and get out.
->any_questions
===any_questions===
Paul: Can we at least stay long enough to get some good footage? I know you want that GameStation 7, and I do too, but looking up stuff about the Glensdale Gorefiend online only gets me so much material.
Jordan: Sure, sure. Now let's get inside.
Jordan: Gotta wonder why they put police tape on a house no one's gonna visit.
Paul: Well, except for us.
Jordan: Before we go inside, does anyone have any questions, newbie? I know you’ve been pretty quiet so far.
->questions
===questions===
+    [...]
Jordan: You there, newbie? Or are you just thinking of a question to ask?
->questions
+    [What are we doing? / Why are we doing this?]
Jordan: We heard this place has some old jewels that should be worth a lot of money. Hopefully it’ll be enough for us to get the new GameStation 7. And, y’know, Paul also came along so he could get footage for a video he’s making.
->questions
+    [What day is it? / What time is it?]
Jordan: It’s Halloween night! Fitting time to go digging around in an abandoned house, huh?
->questions
+    [Who are you people?]
Jordan: I’m Jordan, the main quarterback at Glensdale High. Paul over there is part of the AV Club and apparently has some paranormal blog. Hazel over there… I honestly don’t really know her deal. She came to us with the whole idea for visiting this place. She’s also kind of… odd. Sometimes, I feel like she’s talking to someone we can’t see, and she sometimes *really* insists on us acknowledging what she says. Remember that whole bit with the dog back there?
->questions
+    [Whose idea was this?]
Jordan: Funnily enough, it was Hazel’s idea. She asked us if we wanted to go on an adventure on Halloween night, and when she mentioned the ghostly jewels this place had me and Paul came up with the idea to sell ‘em somewhere so we could buy a GameStation 7.
->questions
+    [Where are we?]
Jordan: We're right outside the haunted house. It's right on the outskirts of Glensdale.
->questions
+    [No questions here.]
Jordan: Alright, lets get to it!
->main_hall
===main_hall===
Hazel: We’re in the main hall now! Look at how big it is!
Paul: Yeah, it’s pretty nice for an abandoned house. The Glensdale Gorefiend has some good taste in interior design. Assuming they’re real and actually live here. It’s kind of spooky.
Jordan: Alright, gang. This place looks like it’s gonna take a while to search, so I think it’d be best for us to split up so we can cover more ground. I’ll go cover the first floor. You think you’ll be okay checking upstairs with Hazel, Paul?
Paul: Sure, I think she’ll be okay with me. Right, Hazel?
Hazel: Wow, this house is muito assustador! (very scary)
Paul: Yeah, she’ll be fine.
Jordan: Hey, newbie. Who do you feel like going with? I think I can manage on my own, but I wouldn’t mind having a second pair of eyes help me look for the jewels.
->team_up
===team_up===
+    [...]
Jordan: Come on, the faster you choose the faster we can start looking! Do you want to go with me or with Paul and Hazel?
->team_up
+    [Jordan]
Jordan: Alright! Stick with me and no ghost or Gorefiend will be messing with us!
->teamed_with_jordan
+    [Paul and Hazel]
Jordan: Cool, I’ll see you three in a bit. Just don’t get grabbed by any monsters! *laughs*
->teamed_with_p_and_h
+    [Why are we splitting up?]
Jordan: This old place is pretty big, and I’m sure you don’t want to stay here any longer than the rest of us do. If we split up, we should be able to find the jewels twice as fast. I’m sure we can hear each other if one of us starts shouting because they found the jewels or something worse.
->team_up
+    [Doesn't that seem dangerous?]
Jordan: Nah, we’ll be fine! I could easily handle any weirdo on my own with my quarterback tackle, and I’m having Paul and Hazel go together so they can outnumber the Glensdale Gorefiend if they *are* hanging out here.
->team_up
===teamed_with_jordan
Jordan: I know you’re new to the area, but I bet you’ve heard about how I helped help bring the Glensdale Gorgons to a narrow 21-20 win against the Barkland Bulls. I tell you, when the big-time football people come calling, that’s the story they’ll be hearing!
Jordan: Right, so the jewels. Obviously, some of it’s going towards the GameStation, but some of that’s definitely going towards getting to a good college. Some folks go to a good college for a good degree, but I’m looking at one with a sick football team. That’s how you get into the big lea-
Jordan: What the hell was that!? (beat) I-I think it came from the kitchen over there. I bet the Glensdale Gorefiend is in there! Newbie, got any idea what to do?
->in_or_not1
===in_or_not1===
+    [...]
Jordan: I could really use an answer now! Should I check out that noise?
->in_or_not1
+    [Go in there.]
->tackling_time
+    [Don't go in there.]
->in_or_not2
===tackling_time===
Jordan: You got it. I’ll show that weirdo my all-star tackling skills!
->jordan_converge
===in_or_not2===
Jordan: (beat) Sorry, I was trying to hear anything going on in there. Did I hear you say “go in there?”
+    [Yes.]
->tackling_time
+    [No.]
Jordan: Yeah, I definitely heard a “go in there.” You wait here, newbie. I’ll handle this.
->jordan_converge
===jordan_converge===
Jordan: Okay, so good news and somewhat-in-the-middle news. There’s no one in the kitchen. That’s when I decided to make a bunch of noise in here so if the Gorefiend IS in the house, they’d be scared off. Hopefully that’ll be the last bit of weirdness we’ll have to deal with.
->alone
===teamed_with_p_and_h
Hazel: We’re on the second floor of the spooky house! I bet we could see the entire town from here!
Paul: Yeah, we probably could, Hazel. So, whats-your-face, you got any cool plans for the money we’ll get from those jewels? Other than the GameStation, mine are pretty simple: better video equipment. I’ve been looking at some stuff to help make my vids really pop. I know some folks say that becoming a popular video maker requires some luck, but I bet some great editing and high-quality footage can help with that!
Paul: Funny story, but I got the idea for doing recordings of haunted places from this game I once saw. In it, this Girl who video tapes haunted locations goes to this abandoned mansion that was owned by some cult that mysteriously vanished, and she-
Hazel: Meu Deus! (Oh my God!) That was loud!
+    [...]
->pauls_phone
+    [What was that noise?]
->pauls_phone
===pauls_phone===
Paul: Riiiiiight, I probably should have mentioned that earlier. That was a ringtone I got for when my mom calls or texts me. I’m a bit hard of hearing so I chose a noise that I’d be sure to hear. Normally, it’s something different, but I figured I’d make it something scary since it’s Halloween. She’s just asking about the party I claimed we were going to.
Paul: That… was not my phone. We have to hide! Where should wo go?
->where_to_run
===where_to_run===
+    [...]
Paul: C’mon, throw out some ideas! Where should we hide?
->where_to_run
+    [Outside.]
Paul: We can’t run! The jewels are still in the house, and whatever’s in here could easily chase us down!
->where_to_run
+    [Basement]
Paul: I was thinking that too! It’ll be extra-dark, there’ll likely be lots of places for us to hide in there, and we might be able to find some tools left down there. Now, back down the stairs!
->basement
+    [Attic]
Paul: Maybe, but if we had to flee, the only other way out is through a window. I don’t think I could take crashing through a third-story window and falling like 30 feet.
->where_to_run
+    [Kitchen]
Paul: Great idea! We’re going right to where the Gorefiend is, or whoever else lives here! C’mon, be serious here!
->where_to_run
===basement===
Paul: Okay, I don’t think anyone’s going to find us down here. (beat) Wait, where did Hazel go? Oh no…
Paul: Wha- the lights turned on!
Hazel: Well done! You found the light switch!
Paul: Hazel! We thought you got lost, or worse! Where were you? Ah, that doesn’t matter now. Anyway, looks like there are some old boxes down here. Help me look through them, you guys.
Paul: Hang on. This house… why does it have power if it’s abandoned? Unless… it *isn’t* abandoned.
->alone
===alone===
*    [Hazel?]
->alone
*    [Paul?]
->alone
*    [Jordan?]
->alone
*    [Hello?]
->alone
*    [Where are you?]
->alone
*    ->theres_hazel
===theres_hazel===
Hazel: Olá, player! It looks like Jordan and Paul have gone missing! Where could they have gone?
Hazel: Did you hear that? It sounded like it came from upstairs! We should go investigate! Vamos lá! (Let’s go!)
Hazel: We’ve reached the top of the stairs, but we still don’t know where our friends are! Where could our friends have been taken?
Hazel: I’ve got an idea! They must be in the attic! Let’s help them!
->the_climatic_encounter
===the_climatic_encounter===
Hazel: We’re in the Glensdale Gorefiend’s lair! Can you find your friends?
Hazel: There they are! They’ve been waiting for you to help them, but you won’t be able to!
Hazel: It gets boring not killing people! That’s why it’s so great to have people come to my lair! That way, I don’t have to worry about most people trying to investigate because of all the scary rumors! Now, do you know what’s going to happen to you and your friends? That’s right! You’re all going to bleed out on the attic floor!
->do_you_want_death
===do_you_want_death===
->do_you_want_death
VAR hazelLoopsRemaining = 3
Hazel: Now, player. Do you want to die?
+    {hazelLoopsRemaining > 0} [...]
~ hazelLoopsRemaining--
   ->do_you_want_death
+    {hazelLoopsRemaining <= 0} [...]
~ hazelLoopsRemaining--
   ->good_ending
+    [Yes.]
Hazel: You’re funny! I wonder if you’d say the same thing after you’re disemboweled!
->bad_end
+    [No.]
Hazel: That’s too bad!
->bad_end
===bad_end===
Hazel: Now, click on who you want to die first!
AI: Thank you for assisting us with the testing of our AI-generated story program. While you were unsuccessful in surviving the story, we are always grateful to our testers for helping us troubleshoot and give us feedback. Please take your complimentary baggie of candy corn as you leave.
    -> END
===lifesaving_update===
AI: Attention tester. We have a new patch available for Project 9th Monday that fixes a few minor bugs. Most notably, this patch will prevent the unintentional crossovers that testers have reported with our AI-generated children’s show generator. Updating now.
Jordan: Bwah! Holy crap! How’d you manage to get the Glensdale Gorefiend to vanish like that?
Paul: I guess those rumors about them being a demon from Hell were true, and you sent them right back there somehow. But seriously, you totally save our lives!
Jordan: Whew, the last time my heart was pounding this much was after that two-hour training session for last season’s final game. Let’s get goin’ home.
Paul: Hang on. We’re in the Gorefiend’s inner sanctum. I want to get a bit of footage of this place and the furniture before we go.
Jordan: Well, I doubt anything else is going to be trying to kill us here. Okay, but not too long.
Paul: Oh man, guys. Three guesses what I found, and I’ll tell you now it’s not anything scary or gory.
Jordan: Wait, are you saying those jewels… are real? I was starting to think it was some rumor the Gorefiend made up!
Paul: Well, it’s time to stop doubting and time to start bringing these riches home!
->good_ending
===good_ending===
AI: Thank you for helping us test out the latest build of Project 9th Monday. In addition, congratulations for reaching the good ending of the story. While the story had to make some adjustments to compensate for the villain’s sudden disappearance, it would seem that it managed to properly remain on track. We are always grateful to our testers for helping us troubleshoot and give us feedback. Please take your assorted package of king-sized candies as you leave the testing site.
-> END