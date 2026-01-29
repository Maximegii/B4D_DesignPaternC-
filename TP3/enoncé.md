# Système de Notification Multi-plateforme

---

Une entreprise de e-commerce souhaite refondre son système de notification pour ses clients. Le système doit gérer différents types de notifications (Commande, Livraison, Support) avec différents niveaux d'urgence, et pouvoir les envoyer via différentes plateformes (Email, SMS, Push mobile).

Voici le code source existant qui nécessite une restructuration :

Questions :

1. Identifiez les problèmes dans le code existant, notamment en termes de :

   - Duplication de code
   - Extensibilité
   - Maintenance
   - Couplage entre les composants

2. Quel pattern de conception permettrait de :
   - Séparer les types de notifications de leurs implémentations
   - Permettre l'évolution indépendante des deux aspects
   - Éviter l'explosion combinatoire des classes
3. Modélisez la solution à l'aide d'un diagramme de classes UML qui permettra de :

   - Découpler les types de notifications des méthodes d'envoi
   - Faciliter l'ajout de nouveaux types de notifications
   - Faciliter l'ajout de nouvelles plateformes d'envoi

4. Comment votre solution faciliterait-elle :

   - L'ajout d'un nouveau type de notification (par exemple "Promotion")
   - L'ajout d'une nouvelle plateforme d'envoi (par exemple "Discord")
   - La modification du comportement d'envoi pour une plateforme spécifique

5. Implémentez la solution proposée en C# en montrant comment elle résout les problèmes identifiés dans le code initial.

Le code fourni présente des signes clairs de duplication et de rigidité. Le pattern approprié permettra de séparer deux aspects qui varient indépendamment l'un de l'autre.
