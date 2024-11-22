### Naming
- Exported: Upper first character
- Unexported: Lower first character

### Logger (Nakama)

| Level  | When to use                                        | Example                                                        |
| ------ | -------------------------------------------------- | -------------------------------------------------------------- |
| DEBUG  | Track detailed execution flow, debug issues        | Debugging variable values in loop or the state of the system   |
| INFO   | Record normal status or system events              | Log when a user successfully logs in                           |
| WARN   | Warn about unexpected events that are not critcal. | Low memory availability, in complete configuration             |
| ERROR  | Log serious errors that need immediately attention | DB connection failure, unexpected system error                 |
| FIELDS | Add context to log for easier tracing              | Log with userID, requestID, or other contextual information.\| |
### Format  for Logger (Nakama)
- `%d` format integers in base 10 (decimal)
- `ms` A string literal representing milliseconds
- `%s` string
- `%f` float point number
- `%` default format for any value
- `%t` bool value (true or false)
- `%x` or `%X` hexadecima representation