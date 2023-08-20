
Access game object :-
Gameobj objname;


hide/show game object :-
objname.setActive(boolean);

We cann take images array as Sprite array.

when script load OnEnable method call automatically.

=====Playerpref=====
using playerpref we can store any data same like localstorage.

to checkKey in playerPref :- playerpref.hasKey(keyname);
to delete key :- playerpref.deleteKey(keyname);

to getcomponent or component children:-

gameObj.GetComponent<compname>()

==== to make button disable/non-disable :-  allLevels[levelNo - 1].GetComponent<Button>().interactable = boolean;