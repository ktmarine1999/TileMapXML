<?xml version="1.0" encoding="UTF-8"?>
<tileset name="outdoor" tilewidth="32" tileheight="32" tilecount="162" columns="9">
 <image source="outdoor.png" trans="ffaa55" width="288" height="576"/>
 <terraintypes>
  <terrain name="Grass" tile="31"/>
  <terrain name="Dirt" tile="28"/>
  <terrain name="Water" tile="51"/>
  <terrain name="Hole" tile="82"/>
 </terraintypes>
 <tile id="1" terrain="1,1,1,0"/>
 <tile id="2" terrain="1,1,0,1"/>
 <tile id="4" terrain="0,0,0,1"/>
 <tile id="5" terrain="0,0,1,0"/>
 <tile id="7" terrain="2,2,2,1">
  <objectgroup draworder="index">
   <object id="3" x="0" y="0">
    <polygon points="0,0 32,0 0,32"/>
   </object>
  </objectgroup>
 </tile>
 <tile id="8" terrain="2,2,1,2">
  <objectgroup draworder="index">
   <object id="1" x="0" y="0">
    <polygon points="0,0 32,0 32,32"/>
   </object>
  </objectgroup>
 </tile>
 <tile id="10" terrain="1,0,1,1"/>
 <tile id="11" terrain="0,1,1,1"/>
 <tile id="13" terrain="0,1,0,0"/>
 <tile id="14" terrain="1,0,0,0"/>
 <tile id="16" terrain="2,1,2,2">
  <objectgroup draworder="index">
   <object id="1" x="0" y="32">
    <polygon points="0,0 0,-32 32,0"/>
   </object>
  </objectgroup>
 </tile>
 <tile id="17" terrain="1,2,2,2">
  <objectgroup draworder="index">
   <object id="1" x="32" y="32">
    <polygon points="0,0 -32,0 0,-32"/>
   </object>
  </objectgroup>
 </tile>
 <tile id="18" terrain="0,0,0,1"/>
 <tile id="19" terrain="0,0,1,1"/>
 <tile id="20" terrain="0,0,1,0"/>
 <tile id="21" terrain="1,1,1,0"/>
 <tile id="22" terrain="1,1,0,0"/>
 <tile id="23" terrain="1,1,0,1"/>
 <tile id="24" terrain="1,1,1,2">
  <objectgroup draworder="index">
   <object id="1" x="32" y="32">
    <polygon points="0,0 0,-32 -32,0"/>
   </object>
  </objectgroup>
 </tile>
 <tile id="25" terrain="1,1,2,2">
  <objectgroup draworder="index">
   <object id="2" x="0" y="16" width="32" height="16"/>
  </objectgroup>
 </tile>
 <tile id="26" terrain="1,1,2,1"/>
 <tile id="27" terrain="0,1,0,1"/>
 <tile id="28" terrain="1,1,1,1"/>
 <tile id="29" terrain="1,0,1,0"/>
 <tile id="30" terrain="1,0,1,0"/>
 <tile id="31" terrain="0,0,0,0"/>
 <tile id="32" terrain="0,1,0,1"/>
 <tile id="33" terrain="1,2,1,2">
  <objectgroup draworder="index">
   <object id="1" x="16" y="0" width="16" height="32"/>
  </objectgroup>
 </tile>
 <tile id="34" terrain="2,2,2,2">
  <objectgroup draworder="index">
   <object id="1" x="0" y="0" width="32" height="32"/>
  </objectgroup>
 </tile>
 <tile id="35" terrain="2,1,2,1">
  <objectgroup draworder="index">
   <object id="1" x="0" y="0" width="16" height="32"/>
  </objectgroup>
 </tile>
 <tile id="36" terrain="0,1,0,0"/>
 <tile id="37" terrain="1,1,0,0"/>
 <tile id="38" terrain="1,0,0,0"/>
 <tile id="39" terrain="1,0,1,1"/>
 <tile id="40" terrain="0,0,1,1"/>
 <tile id="41" terrain="0,1,1,1"/>
 <tile id="42" terrain="1,2,1,1"/>
 <tile id="43" terrain="2,2,1,1">
  <objectgroup draworder="index">
   <object id="1" x="0" y="0" width="32" height="16"/>
  </objectgroup>
 </tile>
 <tile id="44" terrain="2,1,1,1"/>
 <tile id="45" terrain="1,1,1,1"/>
 <tile id="46" terrain="1,1,1,1"/>
 <tile id="47" terrain="1,1,1,1"/>
 <tile id="48" terrain="0,0,0,0"/>
 <tile id="49" terrain="0,0,0,0"/>
 <tile id="50" terrain="0,0,0,0"/>
 <tile id="51" terrain="2,2,2,2">
  <objectgroup draworder="index">
   <object id="1" x="0" y="0" width="32" height="32"/>
  </objectgroup>
  <animation>
   <frame tileid="51" duration="300"/>
   <frame tileid="52" duration="300"/>
   <frame tileid="53" duration="300"/>
   <frame tileid="52" duration="300"/>
  </animation>
 </tile>
 <tile id="55" terrain="3,3,3,1"/>
 <tile id="56" terrain="3,3,1,3"/>
 <tile id="58" terrain="3,3,3,0"/>
 <tile id="59" terrain="3,3,0,3"/>
 <tile id="61" terrain="2,2,2,0">
  <objectgroup draworder="index">
   <object id="1" x="0" y="0">
    <polygon points="0,0 0,32 32,0"/>
   </object>
  </objectgroup>
 </tile>
 <tile id="62" terrain="2,2,0,2">
  <objectgroup draworder="index">
   <object id="2" x="32" y="0">
    <polygon points="0,0 0,32 -32,0"/>
   </object>
  </objectgroup>
 </tile>
 <tile id="64" terrain="3,1,3,3"/>
 <tile id="65" terrain="1,3,3,3"/>
 <tile id="67" terrain="3,0,3,3"/>
 <tile id="68" terrain="0,3,3,3"/>
 <tile id="70" terrain="2,0,2,2">
  <objectgroup draworder="index">
   <object id="1" x="0" y="0">
    <polygon points="0,0 0,32 32,32"/>
   </object>
  </objectgroup>
 </tile>
 <tile id="71" terrain="0,2,2,2">
  <objectgroup draworder="index">
   <object id="1" x="32" y="0">
    <polygon points="0,0 0,32 -32,32"/>
   </object>
  </objectgroup>
 </tile>
 <tile id="72" terrain="1,1,1,3"/>
 <tile id="73" terrain="1,1,3,3"/>
 <tile id="74" terrain="1,1,3,1"/>
 <tile id="75" terrain="0,0,0,3"/>
 <tile id="76" terrain="0,0,3,3"/>
 <tile id="77" terrain="0,0,3,0"/>
 <tile id="78" terrain="0,0,0,2">
  <objectgroup draworder="index">
   <object id="1" x="32" y="32">
    <polygon points="0,0 -32,0 0,-32"/>
   </object>
  </objectgroup>
 </tile>
 <tile id="79" terrain="0,0,2,2">
  <objectgroup draworder="index">
   <object id="1" x="0" y="16" width="32" height="16"/>
  </objectgroup>
 </tile>
 <tile id="80" terrain="0,0,2,0">
  <objectgroup draworder="index">
   <object id="1" x="0" y="32">
    <polygon points="0,0 32,0 0,-32"/>
   </object>
  </objectgroup>
 </tile>
 <tile id="81" terrain="1,3,1,3"/>
 <tile id="82" terrain="3,3,3,3"/>
 <tile id="83" terrain="3,1,3,1"/>
 <tile id="84" terrain="0,3,0,3"/>
 <tile id="86" terrain="3,0,3,0"/>
 <tile id="87" terrain="0,2,0,2">
  <objectgroup draworder="index">
   <object id="1" x="16" y="0" width="16" height="32"/>
  </objectgroup>
 </tile>
 <tile id="89" terrain="2,0,2,0">
  <objectgroup draworder="index">
   <object id="1" x="0" y="0" width="16" height="32"/>
  </objectgroup>
 </tile>
 <tile id="90" terrain="1,3,1,1"/>
 <tile id="91" terrain="3,3,1,1"/>
 <tile id="92" terrain="3,1,1,1"/>
 <tile id="93" terrain="0,3,0,0"/>
 <tile id="94" terrain="3,3,0,0"/>
 <tile id="95" terrain="3,0,0,0"/>
 <tile id="96" terrain="0,2,0,0">
  <objectgroup draworder="index">
   <object id="1" x="0" y="0">
    <polygon points="0,0 32,0 32,32"/>
   </object>
  </objectgroup>
 </tile>
 <tile id="97" terrain="2,2,0,0">
  <objectgroup draworder="index">
   <object id="2" x="0" y="0" width="32" height="16"/>
  </objectgroup>
 </tile>
 <tile id="98" terrain="2,0,0,0">
  <objectgroup draworder="index">
   <object id="1" x="0" y="0">
    <polygon points="0,0 0,32 32,0"/>
   </object>
  </objectgroup>
 </tile>
 <tile id="155">
  <animation>
   <frame tileid="155" duration="200"/>
   <frame tileid="154" duration="200"/>
   <frame tileid="153" duration="400"/>
   <frame tileid="154" duration="200"/>
   <frame tileid="155" duration="200"/>
  </animation>
 </tile>
 <tile id="158">
  <animation>
   <frame tileid="158" duration="200"/>
   <frame tileid="157" duration="200"/>
   <frame tileid="156" duration="400"/>
   <frame tileid="157" duration="200"/>
   <frame tileid="158" duration="200"/>
  </animation>
 </tile>
</tileset>
