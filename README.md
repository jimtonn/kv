# kv

kv is a command-line utility for persisting data to disk and abstracting it as key-value pairs.

## Examples
`kv set mykey myvalue` *sets the value for "mykey" to "myvalue"*

`kv get myvalue` *sends the current value for "mykey" to the standard output`

`kv dump` *lists all keys and values in the store*

## Why would anyone need this?
[AutoHotKey](https://www.autohotkey.com/). (Or other scripting.) If you write a lot of AHK scripts, you've probably encountered a situation where you want to send a password somewhere, but it's unpleasant to embed the password value directly in your script. You also might want to share the same information across multiple scripts. Using the [kv.ahk](https://github.com/jimtonn/kv/blob/master/AHK/kv.ahk) include, you can easily pull values from kv into your AHK scripts.
