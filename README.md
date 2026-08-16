# Audune Social Integration

[![openupm](https://img.shields.io/npm/v/com.audune.social?label=openupm&registry_uri=https://package.openupm.com)](https://openupm.com/packages/com.audune.social/)

Unified integration of social SDKs in your game. Supports getting the current user, setting rich presence, and handling game overlays. Separate social providers are installed using separate packages:

See the [wiki](https://github.com/audunegames/social-integration/wiki) of the repository to get started with the package.

## Features

* A social system component that handles social providers that implement game SDKs for social networks.
* Get the current user, including status and avatar, for all social providers.
* Set rich presence for all social providers.
* Handle activation of game overlays for all social providers.

## Installation

### Requirements

This package depends on the following packages:

* [UniTask](https://openupm.com/packages/com.cysharp.unitask/), version **2.5.11** or higher.

If you're installing the required packages from the [OpenUPM registry](https://openupm.com/), make sure to add a scoped registry with the URL `https://package.openupm.com` and the required scopes before installing the packages.

### Installing from the OpenUPM registry

To install this package as a package from the OpenUPM registry in the Unity Editor, use the following steps:

* In the Unity editor, navigate to **Edit › Project Settings... › Package Manager**.
* Add the following Scoped Registry, or edit the existing OpenUPM entry to include the new Scope:

```
Name:     package.openupm.com
URL:      https://package.openupm.com
Scope(s): com.audune.social
```

* Navigate to **Window › Package Manager**.
* Click the **+** icon and click **Add package by name...**
* Enter the following name in the corresponding field and click **Add**:

```
com.audune.social
```

### Installing as a Git package

To install this package as a Git package in the Unity Editor, use the following steps:

* In the Unity editor, navigate to **Window › Package Manager**.
* Click the **+** icon and click **Add package from git URL...**
* Enter the following URL in the URL field and click **Add**:

```
https://github.com/audunegames/social-integration.git
```

## License

This package is licensed under the GNU LGPL 3.0 license. See `LICENSE.txt` for more information.
