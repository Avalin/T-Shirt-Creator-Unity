#NOTES
You should design your app so that
● It is easy to use
- App is fairly easy to use. Navigating through textures are intuitive in every language.
- Colors can be changed by clicking the picture of current color using an intuitive color picker.
- All buttons have a title revealing what button-group they're a part of. Aside from the t-shirt-shape buttons, but these are color-coded to specified gender.


● It is possible to create hundreds of different designs based on colours,
patterns, shapes and textures
- Hundreds? Hah, try a dozillion-million. Color picker makes possibilities eternal!
- Some shaders take in multiple textures and even multiple colors for even more possibilities!

● The user could make a futuristic design with animated print
- I made a logo based shader (utilizing splashmaps) in which the logo will disappear and reappear! Oooh, spooky!
- I made a different kind of multi-texture shader with 2 different color/texture inputs, these textures will wobble around with "sin(color*time)" function! Funky stuff.

● The user could personalize the design by adding custom text
- Took the easy way and used TextMesh Pro and not a shader :( Sorry. Google showed me no mercy with this.

#BUGS
- At this point, they're so minor I'd like to call them features
- If no material is selected, t-shirt won't respond intuitively to button presses
- ColorPicker slider resets itself if mouseclick isn't released within it