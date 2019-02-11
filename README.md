# kv

kv is a Windows command-line utility for persisting data to disk and abstracting it as key-value pairs.

## Examples
`kv set mykey myvalue` *sets the value for `mykey` to `myvalue`*

`kv get mykey` *gets the current value for `mykey` and outputs it to the standard output*

`kv dump` *lists all keys and values in the store*

`kv c:\temp\data.txt set mykey myvalue` *sets a value in a custom store*

`kv delete mykey` *removes a key (and value) from a store*

A store is a text file that is created either in the folder where you run kv (kvstore.txt by default) or at a location you specify. They are generally human-readable, but values are stored in Base64 so they can contain special characters linebreaks.

## Why would anyone need this?
For [AutoHotKey](https://www.autohotkey.com/), or batch files. If you write a lot of AHK scripts, you've probably encountered a situation where you want to send a password somewhere, but it's unpleasant to embed the password value directly in your script. You also might want to share the same information across multiple scripts. Using the [kv.ahk](https://github.com/jimtonn/kv/blob/master/AHK/kv.ahk) include, you can easily pull values from kv into your AHK scripts.

For example, you could load some data into a store from the command line like this
```
kv set websites.myfavoritewebsite.username noone@nowhere.com
kv set websites.myfavoritewebsite.password p@$$word
```

Then create an AHK script like this:

```
#Include kv.ahk
kv := new kv()
Run, chrome.exe "https://myfavoritewebsite.com"
Sleep, 2000
un := kv.Get("websites.myfavoritewebsite.username")
pw := kv.Get("websites.myfavoritewebsite.password")
Send %un%{tab}%pw%{tab}{enter}
```

## Binaries
You can download the pre-built executable [here](https://github.com/jimtonn/kv/releases) (13kb).
