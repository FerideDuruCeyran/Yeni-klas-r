import java.util.ArrayList;
import java.util.Arrays;
import java.util.Collections;
import java.util.List;
import java.util.Random;

public class PokerHand implements Comparable<PokerHand> {
    private final List<Card> cards;

    public PokerHand(String[] cardStrings) {
        cards = new ArrayList<>();
        for (String cardString : cardStrings) {
            cards.add(new Card(cardString));
        }
        Collections.sort(cards);
    }

    @Override
    public int compareTo(PokerHand other) {
        int thisCategory = getCategoryValue(this.evaluateHand());
        int otherCategory = getCategoryValue(other.evaluateHand());

        if (thisCategory != otherCategory) {
            return Integer.compare(thisCategory, otherCategory);
        } else {
            int thisHighestCard = this.cards.getLast().getRank();
            int otherHighestCard = other.cards.getLast().getRank();
            return Integer.compare(thisHighestCard, otherHighestCard);
        }
    }

    private int getCategoryValue(String category) {
        return switch (category) {
            case "Royal Flush" -> 10;
            case "Straight Flush" -> 9;
            case "Four of a Kind" -> 8;
            case "Full House" -> 7;
            case "Flush" -> 6;
            case "Straight" -> 5;
            case "Three of a Kind" -> 4;
            case "Two Pair" -> 3;
            case "Pair" -> 2;
            default -> 1;
        };
    }

    public String evaluateHand() {
        if (isRoyalFlush()) {
            return "Royal Flush";
        } else if (isStraightFlush()) {
            return "Straight Flush";
        } else if (isFourOfAKind()) {
            return "Four of a Kind";
        } else if (isFullHouse()) {
            return "Full House";
        } else if (isFlush()) {
            return "Flush";
        } else if (isStraight()) {
            return "Straight";
        } else if (isThreeOfAKind()) {
            return "Three of a Kind";
        } else if (isTwoPair()) {
            return "Two Pair";
        } else if (isPair()) {
            return "Pair";
        } else {
            return "High Card";
        }
    }

    private boolean isRoyalFlush() {
        return isStraightFlush() && cards.getLast().getRank() == 14;
    }

    private boolean isStraightFlush() {
        return isFlush() && isStraight();
    }

    private boolean isFourOfAKind() {
        for (int i = 0; i <= cards.size() - 4; i++) {
            if (cards.get(i).getRank() == cards.get(i + 1).getRank()
                    && cards.get(i + 1).getRank() == cards.get(i + 2).getRank()
                    && cards.get(i + 2).getRank() == cards.get(i + 3).getRank()) {
                return true;
            }
        }
        return false;
    }

    private boolean isFullHouse() {
        return (cards.get(0).getRank() == cards.get(1).getRank() && cards.get(2).getRank() == cards.get(3).getRank()
                && cards.get(3).getRank() == cards.get(4).getRank())
                || (cards.get(0).getRank() == cards.get(1).getRank() && cards.get(1).getRank() == cards.get(2).getRank()
                && cards.get(3).getRank() == cards.get(4).getRank());
    }

    private boolean isFlush() {
        return cards.getFirst().getSuit().equals(cards.getLast().getSuit());
    }

    private boolean isStraight() {
        for (int i = 0; i < cards.size() - 1; i++) {
            if (cards.get(i + 1).getRank() - cards.get(i).getRank() != 1) {
                return false;
            }
        }
        return true;
    }

    private boolean isThreeOfAKind() {
        for (int i = 0; i <= cards.size() - 3; i++) {
            if (cards.get(i).getRank() == cards.get(i + 1).getRank()
                    && cards.get(i + 1).getRank() == cards.get(i + 2).getRank()) {
                return true;
            }
        }
        return false;
    }

    private boolean isTwoPair() {
        return (cards.get(0).getRank() == cards.get(1).getRank() && cards.get(2).getRank() == cards.get(3).getRank())
                || (cards.get(0).getRank() == cards.get(1).getRank() && cards.get(3).getRank() == cards.get(4).getRank())
                || (cards.get(1).getRank() == cards.get(2).getRank() && cards.get(3).getRank() == cards.get(4).getRank());
    }

    private boolean isPair() {
        for (int i = 0; i < cards.size() - 1; i++) {
            if (cards.get(i).getRank() == cards.get(i + 1).getRank()) {
                return true;
            }
        }
        return false;
    }

    public static void main(String[] args) {
        String[] deck = generateDeck();
        shuffleDeck(deck);

        String[] hand1 = Arrays.copyOfRange(deck, 0, 5);
        String[] hand2 = Arrays.copyOfRange(deck, 5, 10);

        PokerHand pokerHand1 = new PokerHand(hand1);
        PokerHand pokerHand2 = new PokerHand(hand2);

        System.out.println("Hand 1: " + Arrays.toString(hand1) + " - " + pokerHand1.evaluateHand());
        System.out.println("Hand 2: " + Arrays.toString(hand2) + " - " + pokerHand2.evaluateHand());

        int result = pokerHand1.compareTo(pokerHand2);
        if (result > 0) {
            System.out.println("Hand 1 wins!");
        } else if (result < 0) {
            System.out.println("Hand 2 wins!");
        } else {
            System.out.println("It's a tie!");
        }
    }

    private static String[] generateDeck() {
        String[] ranks = {"2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A"};
        String[] suits = {"S", "C", "H", "D"};
        String[] deck = new String[52];
        int index = 0;

        for (String suit : suits) {
            for (String rank : ranks) {
                deck[index++] = suit + rank;
            }
        }

        return deck;
    }

    private static void shuffleDeck(String[] deck) {
        List<String> deckList = Arrays.asList(deck);
        Collections.shuffle(deckList, new Random());
        deckList.toArray(deck);
    }

    static class Card implements Comparable<Card> {
        private final String suit;
        private final int rank;

        public Card(String cardString) {
            this.suit = cardString.substring(0, 1);
            String rankStr = cardString.substring(1);
            switch (rankStr) {
                case "A":
                    this.rank = 14;
                    break;
                case "K":
                    this.rank = 13;
                    break;
                case "Q":
                    this.rank = 12;
                    break;
                case "J":
                    this.rank = 11;
                    break;
                case "10":
                    this.rank = 10;
                    break;
                default:
                    this.rank = Integer.parseInt(rankStr);
            }
        }

        public String getSuit() {
            return suit;
        }

        public int getRank() {
            return rank;
        }

        @Override
        public int compareTo(Card other) {
            return Integer.compare(this.rank, other.rank);
        }

        @Override
        public String toString() {
            return suit + rank;
        }
    }
}
