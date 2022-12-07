export const findDotColor = (color: string): string => {
  let colorValue: string;
  return color == "red" ||
    color == "blue" ||
    color == "yellow" ||
    color == "white" ||
    color == "green" ||
    color == "grey" ||
    color == "black"
    ? color
    : "white";
}
export const  findBgColor = (color: string): string => {
  let bgClass: string;
  switch (color) {
    case "red": {
      bgClass = "bgRed";
      break;
    }
    case "blue": {
      bgClass = "bgBlue";
      break;
    }
    case "black": {
      bgClass = "bgBlack";
      break;
    }
    case "white": {
      bgClass = "bgWhite";
      break;
    }
    case "yellow": {
      bgClass = "bgYellow";
      break;
    }
    case "green": {
      bgClass = "bgGreen";
      break;
    }
    case "grey": {
      bgClass = "bgGrey";
      break;
    }
    default: {
      bgClass = "bgWhite";
    }
  }
  return bgClass;
}
