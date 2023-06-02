<div id="top"></div>

[![Contributors][contributors-shield]][contributors-url]
[![Forks][forks-shield]][forks-url]
[![Stargazers][stars-shield]][stars-url]
[![Issues][issues-shield]][issues-url]
[![LinkedIn][linkedin-shield]][linkedin-url]



<!-- PROJECT LOGO -->
<br />
<div align="center">
  <a href="#">
    <img src="https://www.pngitem.com/pimgs/m/129-1298621_fire-safety-logo-png-transparent-png.png" alt="Logo" width="80" height="80">
  </a>

  <h3 align="center">PyroSafe</h3>

  <p align="center">
    Welcome to PyroSafe!
    <br />
    <a href="https://github.com/mr-talukdar/Pyrosafe-Game"><strong>Explore the docs »</strong></a>
    <br />
    <br />
    <a href="https://github.com/mr-talukdar/Pyrosafe-Game/releases/tag/demo">View Demo</a>
    ·
    <a href="https://github.com/mr-talukdar/Pyrosafe-Game/issues">Report Bug</a>
    ·
    <a href="https://github.com/mr-talukdar/Pyrosafe-Game/issues">Request Feature</a>
  </p>
</div>



<!-- TABLE OF CONTENTS 
<details>
  <summary>Table of Contents</summary>
  <ol>
    <li>
      <a href="#about-the-project">About The Project</a>
      <ul>
        <li><a href="#Tools-&-Presence-Platform-SDKs-Used">Tools & Presence Platform SDKs Used</a></li>
      </ul>
    </li>
    <li>
      <a href="#getting-started">Getting Started</a>
      <ul>
        <li><a href="#prerequisites">Prerequisites</a></li>
        <li><a href="#installation">Installation</a></li>
      </ul>
    </li>
    <li><a href="#usage">Usage</a></li>
    <li><a href="#roadmap">Roadmap</a></li>
    <li><a href="#contributing">Contributing</a></li>
    <li><a href="#license">License</a></li>
    <li><a href="#contact">Contact</a></li>
    <li><a href="#acknowledgments">Acknowledgments</a></li>
  </ol>
</details>
-->


<!-- ABOUT THE PROJECT -->
## About The Project

[![Product Name Screen Shot][product-screenshot]](https://www.pngitem.com/pimgs/m/129-1298621_fire-safety-logo-png-transparent-png.png)

Professor Jeremy Bailenson once said that in XR, you should do things you can't do in real life yet, such as fly to the moon; or you should do things that are dangerous, like jumping off a cliff. 
The issue we are dealing with is the lack of proper training to deal with fire accidents that may accelerate to something bigger. People don't know the types of fires & fire extinguishers and hence are not able to respond to such situations properly. Fire safety training, although mandatory in some places, is still not very popular. Every year, fire accidents claim a lot of lives and cause injuries and leave victims with lifelong scars. A lot of these accidents are actually preventable.

We did a survey amongst our peers (young adults) and found out that shockingly, the place where people lacked knowledge the most was the types of fires and what to do about them. People had very limited knowledge such as - water shouldn't be used on electric fires, however there was a huge chunk of people who didn't know even this piece of basic fact!
Some of the survey takers knew how to use a fire extinguisher, but half of them still didn't know about the types of fires. This is alarming because using the wrong extinguisher can often create explosions or accelerate the fire.

With Meta's Presence platform and an Oculus headset, it is quite easy to train for such hazardous situations in personal and safe spaces. 
Our solution aims at training users on how to respond to fire accidents that have the potential of growing bigger. We use passthrough, hand and voice SDKs to create a fully immersive game learning experience. The users are put in midst of a fire accident situation, and they have to make smart decisions within the given time period to prevent the fire from spreading.

Before the situation is started, the user is given instructions by a virtual assistant about the types of fire and what extinguisher to use for what type. 

We have used passthrough, hand and voice SDK on the Oculus Quest to build this game experience.
Once the insight SDK is released, we plan to use the anchors to have more realistic experiences by using physics and SLAM (Simultaneous Localisation and Mapping).
We plan to use basic user data in the future so that we can create user profiles and have user IDs.
Since we use passthrough SDK, but oculus doesn't make that data public, the privacy of user is secure.

How it Works:
* Introduction - The virtual assistant tells the user about the types of fires, and the types of extinguishers needed for dealing with them.
* Scenario Spawns - A small fire accident scenario is spawned in the user's environment using passthrough API. This scenario simulates an accident that can actually happen and has the potential of accelerating into a big fire. The aim is to stop the fire within a fixed time.
* Scenario Analysis + Understanding - User analyses the situation by looking around the environment. They understand the type of fire and finalise the type of extinguisher they need.
* Scenario Response - User has the freedom to do Hand Based Interactions to respond to the Scenario and Voice Based Commands to tell the Assistant what type of extinguisher to use. There is a countdown timer and the user has to respond before time runs out. The quicker the user responds, the better.
* End - If the correct extinguisher type is selected using the correct voice command, the assistant puts out the fire. Otherwise, the fire spreads. The user receives feedback about their performance on a 3 star rating scale.





<p align="right">(<a href="#top">back to top</a>)</p>



### Tools & Presence Platform SDKs Used

This section should list any major frameworks/libraries used to bootstrap your project. Leave any add-ons/plugins for the acknowledgements section. Here are a few examples.

* [Unity Engine](https://unity.com/)
* [Oculus Integration v34](https://assetstore.unity.com/packages/tools/integration/oculus-integration-82022)
* [Voice SDK](https://developer.oculus.com/experimental/voice-sdk-overview/)
* [Passthrough API](https://developer.oculus.com/experimental/passthrough-api/)
* [Cutom Hands API](https://developer.oculus.com/resources/hands-design-intro/)

<p align="right">(<a href="#top">back to top</a>)</p>


<!--

## Getting Started

This is an example of how you may give instructions on setting up your project locally.
To get a local copy up and running follow these simple example steps.

### Prerequisites

This is an example of how to list things you need to use the software and how to install them.
* npm
  ```sh
  npm install npm@latest -g
  ```

### Installation

_Below is an example of how you can instruct your audience on installing and setting up your app. This template doesn't rely on any external dependencies or services._

1. Get a free API Key at [https://example.com](https://example.com)
2. Clone the repo
   ```sh
   git clone https://github.com/your_username_/Project-Name.git
   ```
3. Install NPM packages
   ```sh
   npm install
   ```
4. Enter your API in `config.js`
   ```js
   const API_KEY = 'ENTER YOUR API';
   ```

<p align="right">(<a href="#top">back to top</a>)</p>



<!-- USAGE EXAMPLES 
## Usage

Use this space to show useful examples of how a project can be used. Additional screenshots, code examples and demos work well in this space. You may also link to more resources.

_For more examples, please refer to the [Documentation](https://example.com)_

<p align="right">(<a href="#top">back to top</a>)</p>

-->

<!-- ROADMAP -->
## Roadmap

- [x] Create a Virtual Assistant 
- [x] Create the Environment
- [x] Use voice commands to interact with assistant.
- [x] Make the assistant put out the fire with the appropriate vfx (smoke for co2, etc)
- [x] Star based rating feedback for the game
- [ ] Have User ID and User Profiles
- [ ] Add multiple scenarios for the fire accidents
- [ ] Add Anchors when it is released
- [ ] Add "components" document to easily copy & paste sections of the readme
- [ ] Multi-language Support
    - [x] English
    - [ ] Chinese
    - [ ] Spanish
    - [ ] Russian

See the [open issues](https://github.com/othneildrew/Best-README-Template/issues) for a full list of proposed features (and known issues).

<p align="right">(<a href="#top">back to top</a>)</p>



<!-- CONTRIBUTING 
## Contributing

Contributions are what make the open source community such an amazing place to learn, inspire, and create. Any contributions you make are **greatly appreciated**.

If you have a suggestion that would make this better, please fork the repo and create a pull request. You can also simply open an issue with the tag "enhancement".
Don't forget to give the project a star! Thanks again!

1. Fork the Project
2. Create your Feature Branch (`git checkout -b feature/AmazingFeature`)
3. Commit your Changes (`git commit -m 'Add some AmazingFeature'`)
4. Push to the Branch (`git push origin feature/AmazingFeature`)
5. Open a Pull Request

<p align="right">(<a href="#top">back to top</a>)</p>



<!-- LICENSE 
## License

Distributed under the MIT License. See `LICENSE.txt` for more information.

<p align="right">(<a href="#top">back to top</a>)</p>



<!-- CONTACT 
## Contact

Your Name - [@your_twitter](https://twitter.com/your_username) - email@example.com

Project Link: [https://github.com/your_username/repo_name](https://github.com/your_username/repo_name)

<p align="right">(<a href="#top">back to top</a>)</p>



<!-- ACKNOWLEDGMENTS -->
## Acknowledgments

This Project wouldnt have been possible without,

* [Royalty Free Music From Bensound](https://www.bensound.com/)
* [Abstract vector created by freepik - www.freepik.com](https://www.freepik.com/vectors/abstract)
* [Malven's Flexbox Cheatsheet](https://flexbox.malven.co/)
* [Malven's Grid Cheatsheet](https://grid.malven.co/)
* [Img Shields](https://shields.io)
* [GitHub Pages](https://pages.github.com)
* [Font Awesome](https://fontawesome.com)
* [React Icons](https://react-icons.github.io/react-icons/search)
* [Royalty Free 3D models from CGTrader](https://www.cgtrader.com/)
* [Blender](https://www.blender.org/)
* [Unity](https://unity.com/)
* [Oculus](https://www.oculus.com/)

## Meet the Team!

* [Anirban Das](https://www.linkedin.com/in/anirbandas52134)
* [Dipayan Chowdhury](https://www.linkedin.com/in/dipayanchowdhury)
* [Rahul Talukdar](https://www.linkedin.com/in/mr-talukdar)
* [Sanchit Sharma](https://www.linkedin.com/in/sanchitgng)

<p align="right">(<a href="#top">back to top</a>)</p>



<!-- MARKDOWN LINKS & IMAGES -->
<!-- https://www.markdownguide.org/basic-syntax/#reference-style-links -->
[contributors-shield]: https://img.shields.io/github/contributors/othneildrew/Best-README-Template.svg?style=for-the-badge
[contributors-url]: https://github.com/mr-talukdar/Pyrosafe-Game/issues
[forks-shield]: https://img.shields.io/github/forks/othneildrew/Best-README-Template.svg?style=for-the-badge
[forks-url]: https://github.com/mr-talukdar/Pyrosafe-Game/network/members
[stars-shield]: https://img.shields.io/github/stars/othneildrew/Best-README-Template.svg?style=for-the-badge
[stars-url]: https://github.com/mr-talukdar/Pyrosafe-Game/stargazers
[issues-shield]: https://img.shields.io/github/issues/othneildrew/Best-README-Template.svg?style=for-the-badge
[issues-url]: https://github.com/mr-talukdar/Pyrosafe-Game/issues
[linkedin-shield]: https://img.shields.io/badge/-LinkedIn-black.svg?style=for-the-badge&logo=linkedin&colorB=555
[linkedin-url]: https://www.linkedin.com/in/mr-talukdar/
[product-screenshot]: https://github.com/mr-talukdar/Pyrosafe-Game/blob/master/Images/wjorxxjg6jsfywddmtxo.png
