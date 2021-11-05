# Screenshot
A vendor plugin for [Saber](https://saber.datasilk.io) that allows webmasters to browse an online market of website templates that they can download & use as a starting point.

### Prerequisites
* [Saber](https://saber.datasilk.io) ([latest release](https://github.com/Datasilk/Saber/releases))

### Installation
#### For Visual Studio Users
* Clone this repository inside your Saber project within `/App/Vendors/` and name the folder **Screenshot**
	> NOTE: use `git clone` instead of `git submodule add` since the contents of the Vendor folder is ignored by git
* Run `gulp vendors` from the root of your Saber project folder

#### For DevOps Users
While using the latest release of Saber, do the following:
* Download latest release of [Saber.Vendors.Screenshot](https://github.com/Datasilk/Saber-Screenshot/releases)
* Extract all files & folders from either the `win-x64` or `linux-x64` zip folder to Saber's `/Vendors/` folder

### Publish
* run command `./publish.bat`
* publish `bin/Publish/Screenshot.7z` as latest release

### Use Public API
```js
S.ajax.post('Screenshot/Take', {url:'/blog/2021-11-05-Late-Night-Coding', width:1920, height:1080}, (response) => {apikey:'Y0UR-AP1-K3Y'});
```

Access the screenshot abilities from your own Saber plugin by using the JavaScript snippet above. Replace the `url` property with a relative web page URL 
that belongs to your Saber website. You'll be required to add a Public API developer key to your
`config.json` for Saber and use the developer key in place of `Y0UR-AP1-K3Y` in the example above.
