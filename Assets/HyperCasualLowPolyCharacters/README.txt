How to setup animation(I'll use downloaded_animation.fbx - fiction name just for example) downloaded from Mixamo:

1) Import downloaded_animation.fbx to Unity project. Select it.
Inspector Tab => Rig => Animation Type => Humanoid => Apply.

2) Create Animation Controller. Double click on it.
Animator Tab => Right click => Create State => Empty.
Select created state. Inspector Tab => Motion field => Drag and drop animation clip from inside downloaded_animation.fbx node(usually named - mixamo.com)

2a) You can loop animation clip. Select downloaded_animation.fbx. Inspector Tab => Animation => Loop Time => Check box => Apply.

3) Hierarchy Tab => Select character prefab => Animator => Controller field => Drag and drop here Animation Controller created in paragraph 2.

4) Press Play button.



Basic Controls.

1) Press Play button.

2) Screen Right side click - next character.



Contact me if you have any question:
aleksandr.gorodiski@gmail.com
