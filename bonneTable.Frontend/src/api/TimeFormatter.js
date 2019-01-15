export function formatTime(date) {
  var day = date.getDate();
  var month = date.getMonth() + 1;
  var year = date.getFullYear();
  var hour = date.getHours();
  var minute = date.getMinutes();
  var second = date.getSeconds();

  var time =
    month + "-" + day + "-" + year + " " + hour + ":" + minute + ":" + second;
  return time;
}
