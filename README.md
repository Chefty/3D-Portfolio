<h1 align="center">
  <br>
	<a href="https://github.com/Chefty/3D-Portfolio/blob/master/Assets/Textures/3d_portfolio_screenshot.png?raw=true"><img src="https://github.com/Chefty/3D-Portfolio/blob/master/Assets/Textures/3d_portfolio_screenshot.png?raw=true" alt="Markdownify" ></a>
  <br>
  3D Portfolio
</h1>

<h4 align="center">
A 3D version of my portfolio made with <a href="https://unity.com" target="_blank">Unity</a>.</h4>

<!--- <p align="center">
  <a href="https://www.paypal.me/AmitMerchant">
    <img src="https://img.shields.io/badge/$-donate-ff69b4.svg?maxAge=2592000&amp;style=flat">
  </a>
</p>--->

<p align="center">
  <a href="#how-to-use">How To Use</a> •
  <a href="#license">License</a> •
  <a href="#credits">Credits</a>
</p>

<!---![screenshot](https://lien-vers-un-gif)--->
# What is it exactly ?
<table>
<tr>
<td>
I made this simple Unity 3D scene to show my experiences and projects in a different way. I thought it would be more original than my website since I'm not a web designer...<br>
Programs, Level design, most of texture, materials and animations are made by myself. Although I used third party assets.
</td>
</tr>
</table>

## How To Use
Try it right away with the <a href="https://chefty.github.io/assets/unity/portfolio3d/" target="_blank">WebGL</a> version.<br>
Or you can <a href="https://chefty.github.io/projects/" target="_blank">download</a> the Windows installer for PC version (more stable).

To clone and run this application, you will need:
- A Git compatible version control system (e.g [Git](https://git-scm.com))
- [Unity](https://unity.com)

Clone this repository on your computer with. Then open the folder with Unity.
You can start the application straight away by clicking on play or by building an application.

If the scene doesn't display most of the meshes it's because I implemented use of MaterialPropertyBlock. Therefore I could group my materials into a default one and easily merge my meshes to reduce batches/drawcalls.
Everything should be displayed properly on playmode, or you can edit HologramMaterialPropertyBlocks.cs and uncomment "[ExecuteInEditMode]".

## Credits
This application uses the following open source packages:
- [Arcade car physics](https://assetstore.unity.com/packages/tools/physics/arcade-car-physics-119484)
- [POLYGON - Prototype Pack](https://assetstore.unity.com/packages/3d/props/exterior/polygon-prototype-pack-137126)
- [Simplest Mesh Baker](https://assetstore.unity.com/packages/tools/utilities/simplest-mesh-baker-118123)
- [better-unity-webgl-template](https://github.com/greggman/better-unity-webgl-template)
- [KinoGlitch](https://github.com/keijiro/KinoGlitch)
- [HologramShader](https://github.com/andydbc/HologramShader) --- Until I can install URP and use ShaderGraph without unity breaking down.
- OST from [Jean-Michelle Pichet](https://soundcloud.com/user-587306190-320377549/fallback) (who's actually me).

<!---## Support MAYBE FOR LATER
<a href="patreon-link">
	<img src="https://c5.patreon.com/external/logo/become_a_patron_button@2x.png" width="160">
</a>--->

## License

This project itself has no license.
Only the ones from third part assets has to be respected.

---

> GitHub [@Chefty](https://github.com/Chefty) &nbsp;&middot;&nbsp;
