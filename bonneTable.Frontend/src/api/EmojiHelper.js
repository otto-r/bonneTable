export function getClockEmoji(time) {
  if (time == null) {
    return "🕓"
  }
  time = time.getHours() - 1+ ":" + time.getMinutes();

  if (time === "16:0") {
    return "🕓";
  }
  if (time === "16:30") {
    return "🕟";
  }
  if (time === "17:0") {
    return "🕔";
  }
  if (time === "17:30") {
    return "🕠";
  }
  if (time === "18:0") {
    return "🕕";
  }
  if (time === "18:30") {
    return "🕡";
  }
  if (time === "19:0") {
    return "🕖";
  }
  if (time === "19:30") {
    return "🕢";
  }
  if (time === "20:0") {
    return "🕗";
  }
  if (time === "20:30") {
    return "🕣";
  }
  if (time === "21:0") {
    return "🕘";
  }
  if (time === "21:30") {
    return "🕤";
  }

  return "🕓";
}
