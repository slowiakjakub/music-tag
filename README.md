# MusicTag
MusicTag is an application that helps you organize your music library located at your computer. It uses [AcousticID](https://acoustid.org) audio identification service, so it can identify your music files by their contents and not their other meta fields. MusicTag even lets you rename your MP3 files based on the tag information.
#### Note:
MusicTag it's still under development and new updates are regularly coming up, however, you can still download the most working and up to date version from the **main** branch.

# Features
•Supports MP3/WAV audio formats.<br/>
•Recognizing a song with use of an external audio service.<br/>
•Tagging audio file metadata (Title,Artist,Album,Release Date..) based on a file content.<br/>
•Renaming a file based on it's newly fetched metadata.<br/>

MusicTag is based on a [Chromaprint](https://github.com/acoustid/chromaprint) fingerprint-generation alghorithm, which prefers full audio files instead of short, noisy audio recordings (ie. song recorded with a phone, humming).

# How does it work?
Firstly, MusicTag takes an audio file and decompress it into raw PCM format. Then it creates unique compact fingerprint, that allows to identify a song by sending a request to an AcousticID API. MusicTag takes care of returned data, filters it, and tags it into a specific file.

# What is special about MusicTag?
AcousticID Web service returns variety of results from MusicBrainz database. In majority of music tagging apps, different results are displayed to the end user which can be a little confusing. MusicTag filters out all the unnecessary data and gives only the most valuable one to the end-user.

# External libraries
MusicTag makes use of:<br/>
∙ [NAudio](https://github.com/naudio/NAudio) - for audio processing.<br/>
∙ [AcousticID.NET](https://github.com/wo80/AcoustID.NET) - for creating audio fingerprints.<br/>
∙ [Taglib-sharp](https://github.com/mono/taglib-sharp) - for tagging audio files.<br/>
