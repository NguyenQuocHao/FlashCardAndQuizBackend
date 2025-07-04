namespace FlashCardAndQuizBackend.Enums
{
    public enum Register: byte
    {
        //reverse the order of the enum values in this file
        /// <summary>
        /// The most informal level of language, used in personal and intimate settings.
        /// </summary>
        Intimate,
        /// <summary>
        /// The level of language used in casual conversations among friends or acquaintances.
        /// </summary>
        Casual,
        /// <summary>
        /// The level of language used in everyday conversations, suitable for most situations.
        /// </summary>
        Consultative,
        /// <summary>
        /// The level of language used in professional or formal settings, such as business or academic contexts.
        /// </summary>
        Formal,
        /// <summary>
        /// The highest level of formality, often used in official documents or speeches, characterized by a very respectful and polished tone.
        /// </summary>
        Frozen
    }
}
