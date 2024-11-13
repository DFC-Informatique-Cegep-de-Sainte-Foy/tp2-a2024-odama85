using System;
using System.ComponentModel.Design;
using System.Reflection;
using System.Reflection.Metadata.Ecma335;

namespace TP2
{
    public class Game
    {
        #region Constants
        public const int HEART = 0;
        public const int DIAMOND = 1;
        public const int SPADE = 2;
        public const int CLUB = 3;

        public const int ACE = 0;
        public const int TWO = 1;
        public const int THREE = 2;
        public const int FOUR = 3;
        public const int FIVE = 4;
        public const int SIX = 5;
        public const int SEVEN = 6;
        public const int EIGHT = 7;
        public const int NINE = 8;
        public const int TEN = 9;
        public const int JACK = 10;
        public const int QUEEN = 11;
        public const int KING = 12;

        public const int NUM_SUITS = 4;
        public const int NUM_CARDS_PER_SUIT = 13;
        public const int NUM_CARDS = NUM_SUITS * NUM_CARDS_PER_SUIT;
        public const int NUM_CARDS_IN_HAND = 3;

        public const int FACES_SCORE = 10;
        public const int ACES_SCORE = 11;

        public const int MAX_SCORE = 31;
        public const int ALL_SAME_CARDS_VALUE_SCORE = 30;
        public const int ALL_FACES_SCORE = 30;
        public const int ONLY_FACES_SCORE = 28;
        public const int SAME_COLOR_SEQUENCE_SCORE = 28;
        public const int SEQUENCE_SCORE = 26;
        public const int SAME_COLOR_SCORE = 24;

        
        #endregion

        public static int GetSuitFromCardIndex(int index)
        {
            // PROF : À COMPLETER. Le code ci-après est incorrect
            int suit = index / NUM_CARDS_PER_SUIT;
            return suit;
        }
        public static int GetValueFromCardIndex(int index)
        {
            // PROF : À COMPLETER. Le code ci-après est incorrect
            int value = index % NUM_CARDS_PER_SUIT;
            return value;
        }

        public static void DrawFaces(int[] cardValues, bool[] selectedCards, bool[] availableCards)
        {
            // PROF : À COMPLETER.
            Random rnd = new Random();

            for (int i = 0; i < selectedCards.Length; i++)
            {
                if (!selectedCards[i])
                {
                    int cardSelected = rnd.Next(0, availableCards.Length + 1);
                    while (!availableCards[cardSelected])
                    {
                        cardSelected = rnd.Next(0, availableCards.Length + 1);
                    }
                    cardValues[i] = GetValueFromCardIndex(cardSelected);
                    cardValues[i] = cardSelected;
                    availableCards[i] = true;
                }
            }
        }
        public static int GetScoreFromCardValue(int cardValue)
        {
            // PROF : À COMPLETER. Le code ci-après est incorrect
            int scoreCard = 0;
            if (cardValue == ACE)
            {
                scoreCard = ACES_SCORE;
            }
            else if (cardValue == KING || cardValue == QUEEN || cardValue == JACK)
            {
                scoreCard = FACES_SCORE;
            }
            else
            {
                scoreCard = cardValue + 1;
            }

            return scoreCard;
        }
        // Fonction de tri à bulles necessaire pour classer un tableau en ordre
        // afin de ressortir la carte qui a la plus grande valeur à partir de la 
        //fonction GetHighestCardValue
        public static void BubbleSort(int[] values)
        {
            bool isSmaller = false;
            do
            {
                isSmaller = false;
                int element_Temporary = 0;
                for (int i = 0; i < values.Length - 1; i++)
                {
                    if (values[i] > values[i + 1])
                    {
                        isSmaller = true;
                        element_Temporary = values[i];
                        values[i] = values[i + 1];
                        values[i + 1] = element_Temporary;
                    }
                }
            } while (isSmaller);
        }
        // La fonction GetHighestCardValue nous retourne la carte qui a la plus grande valeur
        public static int GetHighestCardValue(int[] values)
        {
            BubbleSort(values);
            int highestCard = -1;
            if (values[0] == ACE)
            {
                highestCard = ACE;
            }
            else
            {
                highestCard = values[values.Length - 1];
            }
            return highestCard;
        }
        public static bool HasOnlySameColorCards(int[] suits)
        {
            bool isSameColor = false;

            for (int i = 0; i < suits.Length; i++) 
            {
                isSameColor = (getColor(suits[0]) == getColor(suits[i])) && (getColor(suits[0]) < 3 && getColor(suits[i]) < 3);
                if(!isSameColor) break;
            }

            return isSameColor;
        }
        public static bool HasAllSameCardValues(int[] values)
        {
            bool isSameValue = false;

            for (int i = 0; i < values.Length; i++)
            {
                isSameValue = values[0] == values[i];
                if (!isSameValue)
                {
                    break;
                }
                  
            }

            return isSameValue;
        }
        public static bool HasAllFaces(int[] values)
        {
            // creer une variable tableau on on va stocker les valeurs de chaque index de carte
            bool isAllFaces = false;
            int [] faces = new int[values.Length];
            // parcourir le toutes les cartes de la manche
            for (int i = 0; i < faces.Length; i++)
            {
                faces[i] = GetScoreFromCardValue(i);

                isAllFaces = faces[i] == 10 || faces[i] == 11 || faces[i] == 12;
                break;
              
            }
            return isAllFaces;

            // pour chaque index, on recupere sa valeur (une fonction pour ca existe deja) et stocker dans le tableau
            // dans le tableau de valeur on verifi qu'on a les valeurs 10, 11, 12
        }

        //public static int GetHandScore(int[] cardIndexes)
        //{
        //    // PROF : À COMPLETER. Le code ci-après est incorrect
        //    return 0;
        //}

        // A COMPLETER
        // ...
        // Il manque toutes les méthodes pour trouver les différentes combinaisons.
        // Référez-vous aux tests pour les noms de fonctions appropriés.
        // ATTENTION! Suivez bien les noms dans les tests, car je vais utiliser mon propre fichier
        // (qui est exactement comme le vôtre, mais vous ne pourrez pas me faire parvenir un fichier
        // de tests avec vos noms de fonctions).
        public static void ShowScore(int[] cardIndexes)
        {
            //int hand = GetHandScore(cardIndexes);
            //Display.WriteString($"Votre score est de : {hand}", 0, Display.CARD_HEIGHT + 14, ConsoleColor.Black);
        }


        #region Fonctions Utilitaires

        public static int getColor(int color) 
        { 
            if(color == SPADE || color == CLUB)
            { 
                return 1; // Noir
            }
            else if (color == HEART || color == DIAMOND)
            {
                return 2; // rouge
            }
            else
            {
                return 3; // autre
            }
        }

      



        #endregion

    }


}

