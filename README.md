# kv

kv is a Windows command-line utility for persisting data to disk and abstracting it as key-value pairs.

## Examples
`kv set mykey myvalue` *sets the value for "mykey" to "myvalue"*

`kv get myvalue` *sends the current value for "mykey" to the standard output`

`kv dump` *lists all keys and values in the store*

## Why would anyone need this?
[AutoHotKey](https://www.autohotkey.com/). (Or other scripting.) If you write a lot of AHK scripts, you've probably encountered a situation where you want to send a password somewhere, but it's unpleasant to embed the password value directly in your script. You also might want to share the same information across multiple scripts. Using the [kv.ahk](https://github.com/jimtonn/kv/blob/master/AHK/kv.ahk) include, you can easily pull values from kv into your AHK scripts.

For example, you could load some data into a store from the command line like this
```
kv set websites.myfavoritewebsite.username noone@nowhere.com
kv set websites.myfavoritewebsite.password pa@ssword
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
