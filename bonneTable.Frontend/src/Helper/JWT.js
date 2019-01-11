export function decode(jwt) {
  var payload = extractPayload(jwt);

  var tobase64 = atob(payload);

  var jwtobj = JSON.parse(tobase64);

  var d = jwtobj.exp * 1000;
  var now = new Date();

  var now_utc = Date.UTC(
    now.getUTCFullYear(),
    now.getUTCMonth(),
    now.getUTCDate(),
    now.getUTCHours(),
    now.getUTCMinutes(),
    now.getUTCSeconds()
  );

  var timeLeft = d - now_utc;

  return timeLeft;
}

function extractPayload(str) {
  const payload = str.match(/\.(.*?)\./);
  return payload ? payload[1] : str;
}
